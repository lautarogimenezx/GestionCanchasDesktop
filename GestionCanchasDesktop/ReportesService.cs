using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace GestionCanchasDesktop
{
    internal static class ReportesService
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

        // ================== Recaudación ==================

        public static DataTable GetRecaudacion(DateTime? desde, DateTime? hasta, string agrupacion = "DIA")
        {
            string groupBy = agrupacion switch
            {
                "SEMANA" => "DATEPART(WEEK, r.Inicio)",
                "MES" => "DATEPART(MONTH, r.Inicio)",
                _ => "CAST(r.Inicio AS DATE)"
            };

            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = $@"
SELECT {groupBy} AS Periodo,
       SUM(DATEDIFF(MINUTE, r.Inicio, DATEADD(MINUTE, r.DuracionMin, r.Inicio)) / 60.0 * c.PrecioHora) AS Total
FROM dbo.Reservas r
JOIN dbo.Canchas c ON c.Id = r.CanchaId
JOIN dbo.Estados e ON e.Id = r.EstadoId
WHERE r.Activo = 1
  AND e.Nombre = N'Pagado'
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY {groupBy}
ORDER BY {groupBy};";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }

        // ================== Horarios más reservados ==================

        public static DataTable GetHorariosMasReservados(DateTime? desde, DateTime? hasta)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = @"
SELECT DATEPART(HOUR, r.Inicio) AS Hora,
       COUNT(*) AS Cantidad
FROM dbo.Reservas r
WHERE r.Activo = 1
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY DATEPART(HOUR, r.Inicio)
ORDER BY Cantidad DESC;";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }

        // ================== Canchero que más recaudó ==================

        public static DataTable GetCancheroTop(DateTime? desde, DateTime? hasta)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = @"
SELECT u.Nombre + ' ' + u.Apellido AS Canchero,
       SUM(DATEDIFF(MINUTE, r.Inicio, DATEADD(MINUTE, r.DuracionMin, r.Inicio)) / 60.0 * c.PrecioHora) AS Total
FROM dbo.Reservas r
JOIN dbo.Canchas c ON c.Id = r.CanchaId
JOIN dbo.Usuarios u ON u.Id = r.CancheroId
JOIN dbo.Estados e ON e.Id = r.EstadoId
WHERE r.Activo = 1
  AND e.Nombre = N'Pagado'
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY u.Nombre, u.Apellido
ORDER BY Total DESC;";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }
    }
}
