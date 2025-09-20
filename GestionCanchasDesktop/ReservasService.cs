using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GestionCanchasDesktop
{
    internal static class ReservasService
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

        // ===================== Combos =====================

        public static DataTable GetJugadoresActivos()
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter(
                "SELECT Id, (Apellido + ', ' + Nombre) AS Nombre FROM dbo.Jugadores WHERE Activo=1 ORDER BY Apellido, Nombre;", cn);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetCanchasActivas()
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter(
                "SELECT Id, (CAST(NroCancha AS NVARCHAR(10)) + ' - ' + Tipo) AS Nombre FROM dbo.Canchas WHERE Activo=1 ORDER BY NroCancha;", cn);
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetEstados()
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter("SELECT Id, Nombre FROM dbo.Estados ORDER BY Id;", cn);
            da.Fill(dt);
            return dt;
        }

        // ===================== Listado =====================

        public static DataTable Listar(DateTime? desde = null, DateTime? hasta = null, bool incluirCanceladas = true)
        {
            var dt = new DataTable();
            using var cn = new SqlConnection(GetCs());

            string sql = @"
SELECT r.Id,
       j.Apellido + ', ' + j.Nombre    AS Jugador,
       CAST(c.NroCancha AS NVARCHAR(10)) + ' - ' + c.Tipo AS Cancha,
       r.Inicio,
       DATEADD(minute, r.DuracionMin, r.Inicio) AS Fin,
       r.DuracionMin,
       e.Nombre AS Estado,
       r.MetodoPago,
       u.Nombre + ' ' + u.Apellido     AS Canchero,
       r.Activo
FROM dbo.Reservas r
JOIN dbo.Jugadores j ON j.Id = r.JugadorId
JOIN dbo.Canchas   c ON c.Id = r.CanchaId
JOIN dbo.Usuarios  u ON u.Id = r.CancheroId
JOIN dbo.Estados   e ON e.Id = r.EstadoId
WHERE (@InclCanceladas = 1 OR r.Activo = 1)
  AND (@Desde IS NULL OR r.Inicio >= @Desde)
  AND (@Hasta IS NULL OR r.Inicio <  @Hasta)
ORDER BY r.Inicio DESC;";

            using var da = new SqlDataAdapter(sql, cn);
            da.SelectCommand!.Parameters.AddWithValue("@InclCanceladas", incluirCanceladas ? 1 : 0);
            da.SelectCommand!.Parameters.AddWithValue("@Desde", (object?)desde ?? DBNull.Value);
            da.SelectCommand!.Parameters.AddWithValue("@Hasta", (object?)hasta ?? DBNull.Value);
            da.Fill(dt);
            return dt;
        }

        // ===================== Disponibilidad =====================

        // Trae reservas del día (rango por fecha; usa índice)
        public static List<(DateTime inicio, int durMin)> GetReservasDeCanchaPorDia(int canchaId, DateTime fechaDia)
        {
            var lista = new List<(DateTime, int)>();
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(@"
SELECT r.Inicio, r.DuracionMin
FROM dbo.Reservas r
WHERE r.CanchaId = @CanchaId
  AND r.Activo = 1
  AND r.Inicio >= @Desde
  AND r.Inicio <  @Hasta;", cn);

            var desde = fechaDia.Date;
            var hasta = desde.AddDays(1);

            cmd.Parameters.AddWithValue("@CanchaId", canchaId);
            cmd.Parameters.AddWithValue("@Desde", desde);
            cmd.Parameters.AddWithValue("@Hasta", hasta);

            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                lista.Add((rd.GetDateTime(0), rd.GetInt32(1)));

            return lista;
        }

        // (opcional) Genera horarios libres - lo dejo por si lo usás en otra vista
        public static List<DateTime> GetHorariosDisponibles(
            int canchaId, DateTime fechaDia, int duracionMin,
            TimeSpan horaApertura, TimeSpan horaCierre, int pasoMin = 30)
        {
            var reservas = GetReservasDeCanchaPorDia(canchaId, fechaDia);
            var libres = new List<DateTime>();

            DateTime inicioVentana = fechaDia.Date + horaApertura;
            DateTime finVentana = fechaDia.Date + horaCierre;
            DateTime ultimoInicio = finVentana.AddMinutes(-duracionMin);

            for (DateTime slot = inicioVentana; slot <= ultimoInicio; slot = slot.AddMinutes(pasoMin))
            {
                DateTime finSlot = slot.AddMinutes(duracionMin);

                bool choca = reservas.Any(r =>
                    slot < r.inicio.AddMinutes(r.durMin) &&
                    finSlot > r.inicio
                );

                if (!choca) libres.Add(slot);
            }
            return libres;
        }

        // ===================== Altas / Cambios =====================

        public static void Crear(int jugadorId, int canchaId, int cancheroId, DateTime inicio, int duracionMin, int estadoId, string? metodoPago)
        {
            if (EsEstadoPagado(estadoId) && string.IsNullOrWhiteSpace(metodoPago))
                throw new InvalidOperationException("Debe indicar método de pago cuando el estado es Pagado.");

            using var cn = new SqlConnection(GetCs());
            cn.Open();

            // SERIALIZABLE + UPDLOCK/HOLDLOCK para bloquear correctamente el hueco
            using var tx = cn.BeginTransaction(IsolationLevel.Serializable);

            var fin = inicio.AddMinutes(duracionMin);

            // chequeo robusto de solape
            using (var chk = new SqlCommand(@"
SELECT TOP 1 1
FROM dbo.Reservas r WITH (UPDLOCK, HOLDLOCK)
WHERE r.Activo = 1
  AND r.CanchaId = @CanchaId
  AND r.Inicio < @Fin
  AND DATEADD(minute, r.DuracionMin, r.Inicio) > @Inicio;", cn, tx))
            {
                chk.Parameters.AddWithValue("@CanchaId", canchaId);
                chk.Parameters.AddWithValue("@Inicio", inicio);
                chk.Parameters.AddWithValue("@Fin", fin);

                var existeSolape = chk.ExecuteScalar();
                if (existeSolape != null)
                {
                    tx.Rollback();
                    throw new InvalidOperationException("La cancha ya está reservada en ese horario.");
                }
            }

            using var cmd = new SqlCommand(@"
INSERT INTO dbo.Reservas (JugadorId, CanchaId, CancheroId, Inicio, DuracionMin, EstadoId, MetodoPago, Activo)
VALUES (@JugadorId, @CanchaId, @CancheroId, @Inicio, @DuracionMin, @EstadoId, @MetodoPago, 1);", cn, tx);

            cmd.Parameters.AddWithValue("@JugadorId", jugadorId);
            cmd.Parameters.AddWithValue("@CanchaId", canchaId);
            cmd.Parameters.AddWithValue("@CancheroId", cancheroId);
            cmd.Parameters.AddWithValue("@Inicio", inicio);
            cmd.Parameters.AddWithValue("@DuracionMin", duracionMin);
            cmd.Parameters.AddWithValue("@EstadoId", estadoId);
            cmd.Parameters.AddWithValue("@MetodoPago", (object?)metodoPago ?? DBNull.Value);

            cmd.ExecuteNonQuery();
            tx.Commit();
        }

        public static void SetEstado(int reservaId, int estadoId, string? metodoPago)
        {
            if (EsEstadoPagado(estadoId) && string.IsNullOrWhiteSpace(metodoPago))
                throw new InvalidOperationException("Debe indicar método de pago cuando el estado es Pagado.");

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(@"
UPDATE dbo.Reservas
SET EstadoId=@E, MetodoPago=@MP
WHERE Id=@Id;", cn);
            cmd.Parameters.AddWithValue("@E", estadoId);
            cmd.Parameters.AddWithValue("@MP", (object?)metodoPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", reservaId);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Cancelar(int reservaId)
        {
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand("UPDATE dbo.Reservas SET Activo=0 WHERE Id=@Id;", cn);
            cmd.Parameters.AddWithValue("@Id", reservaId);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // helper
        private static bool EsEstadoPagado(int estadoId)
        {
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand("SELECT 1 FROM dbo.Estados WHERE Id=@Id AND Nombre=N'Pagado';", cn);
            cmd.Parameters.AddWithValue("@Id", estadoId);
            cn.Open();
            return cmd.ExecuteScalar() != null;
        }
    }
}
