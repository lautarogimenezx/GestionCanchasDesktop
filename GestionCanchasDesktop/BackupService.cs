using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace GestionCanchasDesktop
{
    internal static class BackupService
    {
        private static string GetCs()
        {
            var cfg = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return cfg.GetConnectionString("CanchaDb")
                ?? throw new InvalidOperationException("Falta ConnectionStrings:CanchaDb en appsettings.json");
        }

        private static string GetDbName()
        {
            var builder = new SqlConnectionStringBuilder(GetCs());
            return builder.InitialCatalog;
        }

        public static void HacerBackup(string rutaBak)
        {
            string db = GetDbName();

            using var cn = new SqlConnection(GetCs());
            cn.Open();

            string sql = $@"
BACKUP DATABASE [{db}]
TO DISK = @Ruta
WITH COPY_ONLY, COMPRESSION, CHECKSUM, INIT, STATS = 10;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Ruta", rutaBak);
            cmd.ExecuteNonQuery();
        }

        public static void RestaurarBackupSeguro(string rutaBak)
        {
            string db = GetDbName();
            var builder = new SqlConnectionStringBuilder(GetCs()) { InitialCatalog = "master" };

            using var cn = new SqlConnection(builder.ConnectionString);
            cn.Open();

            // 1) Verificación: intento WITH CHECKSUM y, si falla por falta de checksums, pruebo sin opción
            try
            {
                using var verify1 = new SqlCommand("RESTORE VERIFYONLY FROM DISK = @Ruta WITH CHECKSUM;", cn);
                verify1.Parameters.AddWithValue("@Ruta", rutaBak);
                verify1.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                using var verify2 = new SqlCommand("RESTORE VERIFYONLY FROM DISK = @Ruta;", cn);
                verify2.Parameters.AddWithValue("@Ruta", rutaBak);
                verify2.ExecuteNonQuery();
            }

            // 2) Restauración
            using var cmd = new SqlCommand($@"
ALTER DATABASE [{db}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE [{db}]
FROM DISK = @Ruta
WITH REPLACE, STATS = 10;

ALTER DATABASE [{db}] SET MULTI_USER;", cn);
            cmd.Parameters.AddWithValue("@Ruta", rutaBak);
            cmd.ExecuteNonQuery();
        }


        public static void RegistrarAuditoria(string accion, string archivo, int usuario1Id, string usuario1Nombre, int? usuario2Id, string? usuario2Nombre, string detalle = "")
        {
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(@"
IF OBJECT_ID('dbo.AuditoriaBackups') IS NULL
BEGIN
    CREATE TABLE dbo.AuditoriaBackups(
        Id INT IDENTITY PRIMARY KEY,
        Fecha DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        Accion NVARCHAR(50) NOT NULL,
        Archivo NVARCHAR(400) NULL,
        Usuario1Id INT NOT NULL,
        Usuario1Nombre NVARCHAR(200) NOT NULL,
        Usuario2Id INT NULL,
        Usuario2Nombre NVARCHAR(200) NULL,
        Detalle NVARCHAR(MAX) NULL
    );
END;

INSERT INTO dbo.AuditoriaBackups(Accion, Archivo, Usuario1Id, Usuario1Nombre, Usuario2Id, Usuario2Nombre, Detalle)
VALUES(@Accion, @Archivo, @U1Id, @U1Nom, @U2Id, @U2Nom, @Det);", cn);

            cmd.Parameters.AddWithValue("@Accion", accion);
            cmd.Parameters.AddWithValue("@Archivo", (object?)archivo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@U1Id", usuario1Id);
            cmd.Parameters.AddWithValue("@U1Nom", usuario1Nombre);
            cmd.Parameters.AddWithValue("@U2Id", (object?)usuario2Id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@U2Nom", (object?)usuario2Nombre ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Det", (object?)detalle ?? DBNull.Value);

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
