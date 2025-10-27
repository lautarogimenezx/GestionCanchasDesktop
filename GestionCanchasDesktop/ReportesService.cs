using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace GestionCanchasDesktop
{
    // Se encarga de todo lo que tenga que ver con la base de datos para los reportes.
    // Así no mezclamos código SQL en el formulario.
    internal static class ReportesService
    {
        // Un método para agarrar la cadena de conexión del archivo appsettings.json.
        private static string GetCs()
        {
            var cfg = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Si no encuentra la connection string, tira un error para que nos demos cuenta.
            return cfg.GetConnectionString("CanchaDb")
                ?? throw new InvalidOperationException("Falta ConnectionStrings:CanchaDb en appsettings.json");
        }

        // ================== Recaudación ==================

        // Este método busca la recaudación y la agrupa como le pidamos.
        public static DataTable GetRecaudacion(DateTime? desde, DateTime? hasta, string agrupacion = "DIA")
        {
            // Dependiendo de lo que elijan en el ComboBox (DIA, SEMANA, MES),
            // armamos un pedacito del SQL para el GROUP BY.
            string groupBy = agrupacion switch
            {
                "SEMANA" => "DATEPART(WEEK, r.Inicio)", // Agrupa por el número de la semana
                "MES" => "DATEPART(MONTH, r.Inicio)",   // Agrupa por el número del mes
                _ => "CAST(r.Inicio AS DATE)"           // Si es "DIA" o cualquier otra cosa, agrupa por fecha exacta
            };

            var dt = new DataTable(); // Acá vamos a guardar los resultados.
            using var cn = new SqlConnection(GetCs());

            // Armamos la consulta SQL.
            string sql = $@"
-- Seleccionamos el período (que puede ser día, semana o mes) y calculamos el total.
-- El total es la duración en horas (por eso el / 60.0) multiplicado por el precio.
SELECT {groupBy} AS Periodo,
       SUM(DATEDIFF(MINUTE, r.Inicio, DATEADD(MINUTE, r.DuracionMin, r.Inicio)) / 60.0 * c.PrecioHora) AS Total
FROM dbo.Reservas r
JOIN dbo.Canchas c ON c.Id = r.CanchaId
JOIN dbo.Estados e ON e.Id = r.EstadoId
WHERE r.Activo = 1
  AND e.Nombre = N'Pagado' -- Solo contamos las que están pagadas.
  AND (@Desde IS NULL OR r.Inicio >= @Desde) -- Filtros de fecha (si existen)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY {groupBy} -- Agrupamos por lo que definimos arriba.
ORDER BY {groupBy};";

            using var da = new SqlDataAdapter(sql, cn);
            // Le pasamos los valores para @Desde y @Hasta. Si son null, usamos DBNull.Value.
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);

            da.Fill(dt); // Llenamos la tabla con los datos de la consulta.
            return dt;
        }

        // ================== Horarios más reservados ==================

        // Cuenta cuántas veces se reservó cada hora.
        public static DataTable GetHorariosMasReservados(DateTime? desde, DateTime? hasta)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = @"
-- Saca la hora de la fecha de inicio y la cuenta.
SELECT DATEPART(HOUR, r.Inicio) AS Hora,
       COUNT(*) AS Cantidad
FROM dbo.Reservas r
WHERE r.Activo = 1
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY DATEPART(HOUR, r.Inicio) -- Agrupamos por hora.
ORDER BY Cantidad DESC;";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }

        // ================== Canchero que más recaudó ==================

        // Parecido al de recaudación, pero agrupa por canchero para ver quién hizo más plata.
        public static DataTable GetCancheroTop(DateTime? desde, DateTime? hasta)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = @"
-- Juntamos nombre y apellido para que se vea bien.
SELECT u.Nombre + ' ' + u.Apellido AS Canchero,
       SUM(DATEDIFF(MINUTE, r.Inicio, DATEADD(MINUTE, r.DuracionMin, r.Inicio)) / 60.0 * c.PrecioHora) AS Total
FROM dbo.Reservas r
JOIN dbo.Canchas c ON c.Id = r.CanchaId
JOIN dbo.Usuarios u ON u.Id = r.CancheroId -- Hacemos JOIN con Usuarios para sacar el nombre.
JOIN dbo.Estados e ON e.Id = r.EstadoId
WHERE r.Activo = 1
  AND e.Nombre = N'Pagado'
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio < @Hasta)
GROUP BY u.Nombre, u.Apellido -- Agrupamos por el canchero.
ORDER BY Total DESC;";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }
    }
}