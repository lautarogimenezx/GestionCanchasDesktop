using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace GestionCanchasDesktop
{
    internal static class JugadoresService
    {
        // === Conexión
        private static string GetCs()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("CanchaDb")
                ?? throw new InvalidOperationException("Falta ConnectionStrings:CanchaDb en appsettings.json");
        }

        public static DataTable Listar(bool incluirInactivos = false)
        {
            var dt = new DataTable();
            string sql = @"
SELECT Id, Nombre, Apellido, Telefono, Activo
FROM dbo.Jugadores
" + (incluirInactivos ? "" : "WHERE Activo = 1 ") +
"ORDER BY Apellido, Nombre;";

            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }

        public static void Crear(string nombre, string apellido, string? telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre requerido");
            if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentException("Apellido requerido");

            const string sql = @"
INSERT INTO dbo.Jugadores (Nombre, Apellido, Telefono, Activo)
VALUES (@Nombre, @Apellido, @Telefono, 1);";

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Nombre", nombre.Trim());
            cmd.Parameters.AddWithValue("@Apellido", apellido.Trim());
            cmd.Parameters.AddWithValue("@Telefono", (object?)telefono ?? DBNull.Value);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Actualizar(int id, string nombre, string apellido, string? telefono, bool activo)
        {
            const string sql = @"
UPDATE dbo.Jugadores
SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Activo=@Activo
WHERE Id=@Id;";

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nombre", nombre.Trim());
            cmd.Parameters.AddWithValue("@Apellido", apellido.Trim());
            cmd.Parameters.AddWithValue("@Telefono", (object?)telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Activo", activo);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void SetActivo(int id, bool activo)
        {
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand("UPDATE dbo.Jugadores SET Activo=@A WHERE Id=@Id;", cn);
            cmd.Parameters.AddWithValue("@A", activo);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // (Borrado real)
        public static void BorrarDefinitivo(int id)
        {
            try
            {
                using var cn = new SqlConnection(GetCs());
                using var cmd = new SqlCommand("DELETE FROM dbo.Jugadores WHERE Id=@Id;", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException("No se puede borrar: el jugador tiene reservas asociadas.", ex);
            }
        }
    }
}
