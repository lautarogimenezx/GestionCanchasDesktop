using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace GestionCanchasDesktop
{
    public record UserInfo(int Id, string Nombre, string Apellido, string Rol);

    internal static class AuthService
    {
        // === Conexión ===
        private static string GetCs()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return config.GetConnectionString("CanchaDb");
        }

        // === LOGIN ===
        public static bool TryLogin(string email, string password, out UserInfo? user)
        {
            user = null;
            const string sql = @"
SELECT u.Id, u.Nombre, u.Apellido, r.Nombre AS Rol, u.PasswordHash, u.Salt, u.Activo
FROM dbo.Usuarios u
JOIN dbo.Roles r ON r.Id = u.RolId
WHERE u.Email = @Email;";

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Email", email);
            cn.Open();

            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return false;

            int id = rd.GetInt32(0);
            string nombre = rd.GetString(1);
            string apellido = rd.GetString(2);
            string rol = rd.GetString(3);
            byte[] hashDb = (byte[])rd["PasswordHash"];
            byte[] saltDb = (byte[])rd["Salt"];
            bool activo = rd.GetBoolean(6);
            if (!activo) return false;

            byte[] hashTry = Sha256Concat(saltDb, password);
            if (!FixedTimeEquals(hashDb, hashTry)) return false;

            user = new UserInfo(id, nombre, apellido, rol);
            return true;
        }

        // === CREAR USUARIO ===
        public static void CrearUsuario(string nombre, string apellido, string email, string password, int rolId, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre requerido");
            if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentException("Apellido requerido");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email requerido");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Contraseña requerida");

            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Sha256Concat(salt, password);

            const string sql = @"
INSERT INTO dbo.Usuarios (RolId,Nombre,Apellido,Email,PasswordHash,Salt,Activo)
VALUES (@RolId,@Nombre,@Apellido,@Email,@PasswordHash,@Salt,@Activo);";

            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@RolId", rolId);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Apellido", apellido);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarBinary, 32).Value = hash;
            cmd.Parameters.Add("@Salt", System.Data.SqlDbType.VarBinary, 16).Value = salt;
            cmd.Parameters.AddWithValue("@Activo", activo);

            cn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new InvalidOperationException("El email ya está registrado.", ex);
            }
        }

        // === LISTAR USUARIOS ===
        public static DataTable ListarUsuarios(bool incluirInactivos = true)
        {
            var dt = new DataTable();
            string sql = @"
SELECT u.Id, u.Nombre, u.Apellido, u.Email, r.Nombre AS Rol, u.Activo
FROM dbo.Usuarios u
JOIN dbo.Roles r ON r.Id = u.RolId
" + (incluirInactivos ? "" : "WHERE u.Activo = 1 ") +
"ORDER BY u.Apellido, u.Nombre;";

            using var cn = new SqlConnection(GetCs());
            using var da = new SqlDataAdapter(sql, cn);
            da.Fill(dt);
            return dt;
        }

        // === ACTIVAR/DESACTIVAR USUARIO ===
        public static void SetActivo(int usuarioId, bool activo)
        {
            const string sql = "UPDATE dbo.Usuarios SET Activo=@Activo WHERE Id=@Id;";
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Activo", activo);
            cmd.Parameters.AddWithValue("@Id", usuarioId);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // === RESET PASSWORD ===
        public static void ResetPassword(int usuarioId, string nuevaPassword)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Sha256Concat(salt, nuevaPassword);

            const string sql = "UPDATE dbo.Usuarios SET PasswordHash=@Hash, Salt=@Salt WHERE Id=@Id;";
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add("@Hash", System.Data.SqlDbType.VarBinary, 32).Value = hash;
            cmd.Parameters.Add("@Salt", System.Data.SqlDbType.VarBinary, 16).Value = salt;
            cmd.Parameters.AddWithValue("@Id", usuarioId);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // === OBTENER ROLES ===
        public static List<(int Id, string Nombre)> GetRoles()
        {
            var lista = new List<(int, string)>();
            const string sql = "SELECT Id, Nombre FROM dbo.Roles ORDER BY Nombre;";
            using var cn = new SqlConnection(GetCs());
            using var cmd = new SqlCommand(sql, cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                lista.Add((rd.GetInt32(0), rd.GetString(1)));
            return lista;
        }

        // === HASHING Y COMPARACIÓN ===
        private static byte[] Sha256Concat(byte[] salt, string password)
        {
            using var sha = SHA256.Create();
            var pwdBytes = Encoding.Unicode.GetBytes(password); // importante: Unicode por NVARCHAR
            var buffer = new byte[salt.Length + pwdBytes.Length];
            Buffer.BlockCopy(salt, 0, buffer, 0, salt.Length);
            Buffer.BlockCopy(pwdBytes, 0, buffer, salt.Length, pwdBytes.Length);
            return sha.ComputeHash(buffer);
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }

        public static void ActualizarUsuario(
    int id, string nombre, string apellido, string email,
    int rolId, bool activo, string? nuevaPassword
)
        {
            using var cn = new SqlConnection(GetCs());
            cn.Open();

            // 1) Duplicado de email (excluyendo al propio id)
            using (var chk = new SqlCommand(
                "SELECT 1 FROM dbo.Usuarios WHERE Email=@Email AND Id<>@Id;", cn))
            {
                chk.Parameters.AddWithValue("@Email", email);
                chk.Parameters.AddWithValue("@Id", id);
                var dup = chk.ExecuteScalar();
                if (dup != null)
                    throw new InvalidOperationException("El email ya está registrado.");
            }

            if (string.IsNullOrEmpty(nuevaPassword))
            {
                // 2a) UPDATE sin tocar password
                using var cmd = new SqlCommand(@"
UPDATE dbo.Usuarios
SET RolId=@RolId, Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Activo=@Activo
WHERE Id=@Id;", cn);
                cmd.Parameters.AddWithValue("@RolId", rolId);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            else
            {
                // 2b) UPDATE cambiando password (salt+hash)
                byte[] salt = RandomNumberGenerator.GetBytes(16);
                byte[] hash = Sha256Concat(salt, nuevaPassword);

                using var cmd = new SqlCommand(@"
UPDATE dbo.Usuarios
SET RolId=@RolId, Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Activo=@Activo,
    PasswordHash=@Hash, Salt=@Salt
WHERE Id=@Id;", cn);
                cmd.Parameters.AddWithValue("@RolId", rolId);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.Add("@Hash", System.Data.SqlDbType.VarBinary, 32).Value = hash;
                cmd.Parameters.Add("@Salt", System.Data.SqlDbType.VarBinary, 16).Value = salt;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
