using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;

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
            var cs = GetCs();
            var builder = new SqlConnectionStringBuilder(cs);
            return builder.InitialCatalog;
        }

        public static void HacerBackup(string ruta)
        {
            string db = GetDbName();

            using var cn = new SqlConnection(GetCs());
            cn.Open();

            string sql = $@"
BACKUP DATABASE [{db}]
TO DISK = @Ruta
WITH INIT, STATS = 10;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Ruta", ruta);
            cmd.ExecuteNonQuery();
        }

        public static void RestaurarBackup(string ruta)
        {
            string db = GetDbName();

            // Nos conectamos al "master" porque no se puede restaurar estando conectado a la misma BD
            var cs = GetCs();
            var builder = new SqlConnectionStringBuilder(cs) { InitialCatalog = "master" };

            using var cn = new SqlConnection(builder.ConnectionString);
            cn.Open();

            string sql = $@"
ALTER DATABASE [{db}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE [{db}]
FROM DISK = @Ruta
WITH REPLACE;

ALTER DATABASE [{db}] SET MULTI_USER;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Ruta", ruta);
            cmd.ExecuteNonQuery();
        }
    }
}
