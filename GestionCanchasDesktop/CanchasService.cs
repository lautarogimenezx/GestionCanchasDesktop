using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Globalization;

namespace GestionCanchasDesktop
{
    internal static class CanchasService
    {
        // === Conexión ===
        private static string GetCs()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("CanchaDb")
                ?? throw new InvalidOperationException("Falta ConnectionStrings:CanchaDb en appsettings.json");
        }

        public static DataTable Listar(bool incluirInactivos = true)
        {
            var dt = new DataTable();
            string sql = @"
SELECT Id, NroCancha, Tipo, Ubicacion, PrecioHora, Activo
FROM dbo.Canchas
" + (incluirInactivos ? "" : "WHERE Activo = 1 ") +
"ORDER BY NroCancha;";

            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }

        public static void Crear(int nro, string tipo, string? ubicacion, decimal precioHora, bool activo)
        {
            if (nro <= 0) throw new ArgumentException("El número de cancha debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("El tipo es requerido.");
            if (precioHora <= 0) throw new ArgumentException("Precio por hora debe ser mayor que 0.");

            const string sql = @"
INSERT INTO dbo.Canchas (NroCancha,Tipo,Ubicacion,PrecioHora,Activo)
VALUES (@Nro,@Tipo,@Ubic,@Precio,@Activo);";

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Nro", nro);
            cmd.Parameters.AddWithValue("@Tipo", tipo.Trim());
            cmd.Parameters.AddWithValue("@Ubic", (object?)ubicacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Precio", precioHora);
            cmd.Parameters.AddWithValue("@Activo", activo);

            cn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // unique
            {
                throw new InvalidOperationException("Ya existe una cancha con ese número.", ex);
            }
        }

        public static void Actualizar(int id, int nro, string tipo, string? ubicacion, decimal precioHora, bool activo)
        {
            if (nro <= 0) throw new ArgumentException("El número de cancha debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("El tipo es requerido.");
            if (precioHora <= 0) throw new ArgumentException("Precio por hora debe ser mayor que 0.");

            using var cn = new SqlConnection(GetCs());
            cn.Open();

            // verificar duplicado de NroCancha
            using (var chk = new SqlCommand(
                "SELECT 1 FROM dbo.Canchas WHERE NroCancha=@Nro AND Id<>@Id;", cn))
            {
                chk.Parameters.AddWithValue("@Nro", nro);
                chk.Parameters.AddWithValue("@Id", id);
                var dup = chk.ExecuteScalar();
                if (dup != null) throw new InvalidOperationException("Ya existe otra cancha con ese número.");
            }

            using var cmd = new SqlCommand(@"
UPDATE dbo.Canchas
SET NroCancha=@Nro, Tipo=@Tipo, Ubicacion=@Ubic, PrecioHora=@Precio, Activo=@Activo
WHERE Id=@Id;", cn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nro", nro);
            cmd.Parameters.AddWithValue("@Tipo", tipo.Trim());
            cmd.Parameters.AddWithValue("@Ubic", (object?)ubicacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Precio", precioHora);
            cmd.Parameters.AddWithValue("@Activo", activo);

            cmd.ExecuteNonQuery();
        }

        public static void SetActivo(int id, bool activo)
        {
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand("UPDATE dbo.Canchas SET Activo=@A WHERE Id=@Id;", cn);
            cmd.Parameters.AddWithValue("@A", activo);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // (Opcional) borrado real: ojo con reservas ligadas
        public static void BorrarDefinitivo(int id)
        {
            try
            {
                using var cn = new SqlConnection(GetCs());
                using var cmd = new SqlCommand("DELETE FROM dbo.Canchas WHERE Id=@Id;", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException("No se puede borrar: la cancha tiene reservas asociadas.", ex);
            }
        }
    }
}
