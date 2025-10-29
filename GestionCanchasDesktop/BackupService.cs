using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;

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

        /// <summary>
        /// Obtiene el directorio de backup por defecto de la instancia SQL.
        /// </summary>
        private static string GetServerDefaultBackupDir(SqlConnection cn)
        {
            // 1) Intento estándar (SQL 2012+)
            using (var cmd = new SqlCommand("SELECT CAST(SERVERPROPERTY('InstanceDefaultBackupPath') AS NVARCHAR(4000));", cn))
            {
                var r = cmd.ExecuteScalar() as string;
                if (!string.IsNullOrWhiteSpace(r)) return r;
            }

            // 2) Fallback vía registro
            using (var cmd = new SqlCommand(
                "DECLARE @dir NVARCHAR(4000);" +
                "EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', " +
                "N'SOFTWARE\\Microsoft\\MSSQLServer\\MSSQLServer', N'BackupDirectory', @dir OUTPUT;" +
                "SELECT @dir;", cn))
            {
                var r = cmd.ExecuteScalar() as string;
                if (!string.IsNullOrWhiteSpace(r)) return r;
            }

            // 3) Último recurso: carpeta típica (puede variar por versión/instancia)
            // El backup igualmente fallará si no coincide, pero rara vez se llega aquí
            return @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup";
        }

        private static bool SoportaCompresion(SqlConnection cn)
        {
            // EngineEdition: 4 = Express (sin compresión de backup)
            using var cmd = new SqlCommand("SELECT CAST(SERVERPROPERTY('EngineEdition') AS INT);", cn);
            var edition = (int)cmd.ExecuteScalar();
            return edition != 4; // true si NO es Express
        }

        public static void HacerBackupSeguro(string destinoUsuario)
        {
            string db = GetDbName();

            using var cn = new SqlConnection(GetCs());
            cn.Open();

            var serverBackupDir = GetServerDefaultBackupDir(cn);
            Directory.CreateDirectory(serverBackupDir);

            var tempName = $"TMP_{db}_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}.bak";
            var serverBakPath = Path.Combine(serverBackupDir, tempName);

            bool puedeComprimir = SoportaCompresion(cn);
            string opciones = puedeComprimir
                ? "COPY_ONLY, CHECKSUM, INIT, STATS = 10, FORMAT"              
                : "COPY_ONLY, CHECKSUM, INIT, STATS = 10, FORMAT";              

            if (puedeComprimir) opciones += ", COMPRESSION";

            // 1) Backup en la carpeta del servidor (cuenta del servicio tiene permisos)
            using (var cmd = new SqlCommand($@"
BACKUP DATABASE [{db}]
TO DISK = @Ruta
WITH {opciones};", cn))
            {
                cmd.Parameters.AddWithValue("@Ruta", serverBakPath);
                cmd.ExecuteNonQuery();
            }

            // 2) Copia al destino elegido por el usuario (con permisos del usuario)
            var destinoFinal = destinoUsuario;
            var destinoDir = Path.GetDirectoryName(destinoFinal)!;
            Directory.CreateDirectory(destinoDir);
            File.Copy(serverBakPath, destinoFinal, overwrite: true);

            // 3) Limpieza del archivo temporal
            try { File.Delete(serverBakPath); } catch { /* best effort */ }
        }

        // --- RESTORE SEGURO ---
        public static void RestaurarBackupSeguro(string rutaBak)
        {
            string db = GetDbName();
            var builder = new SqlConnectionStringBuilder(GetCs()) { InitialCatalog = "master" };

            using var cn = new SqlConnection(builder.ConnectionString);
            cn.Open();

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
