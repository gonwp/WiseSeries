using System.Security.Cryptography;
using System.Text;
using CapaDatos;

namespace CapaNegocios
{
    public class UsuarioBL
    {
        private UsuarioDAL _usuarioDAL;

        public UsuarioBL(string connectionString)
        {
            _usuarioDAL = new UsuarioDAL(connectionString);
        }

        public bool ValidarUsuario(string email, string password)
        {
            // Hashear la contraseña proporcionada por el usuario
            string hashedPassword = HashPassword(password);

            // Validar usuario y contraseña hasheada en la base de datos
            return _usuarioDAL.ValidarUsuario(email, hashedPassword);
        }

        public bool RegistrarUsuario(string email, string password, string nombre)
        {
            // Hashear la contraseña antes de almacenarla
            string hashedPassword = HashPassword(password);

            // Verificar si el usuario ya existe
            if (_usuarioDAL.ExisteUsuario(email))
            {
                return false; // Usuario ya existe
            }

            // Guardar el nuevo usuario en la base de datos
            _usuarioDAL.InsertarUsuario(email, hashedPassword, nombre);
            return true;
        }

        public bool RegistrarUsuarioGoogle(string email, string nombre)
        {
            // Verificar si el usuario ya existe
            if (_usuarioDAL.ExisteUsuario(email))
            {
                return false; // Usuario ya existe
            }

            // Guardar el nuevo usuario en la base de datos
            _usuarioDAL.InsertarUsuarioGoogle(email, nombre);
            return true;
        }

        private string HashPassword(string password)
        {
            // Verificar si la contraseña es nula o vacía
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;  // O puedes retornar un valor predeterminado, o lanzar una excepción si prefieres
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña en bytes y calcular el hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir los bytes del hash en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public int ObtenerUserId(string email)
        {
            return _usuarioDAL.ObtenerUserIdPorEmail(email);
        }

        public bool UsuarioExiste(int userId, string email)
        {
            try
            {
                // Usar el método UsuarioExiste de la capa de datos
                return _usuarioDAL.UsuarioExiste(userId, email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del usuario en la capa de negocios.", ex);
            }
        }
    }
}