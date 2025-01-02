using Npgsql; // Asumes que usas PostgreSQL

namespace CapaDatos
{
    public class UsuarioDAL
    {
        private string _connectionString;

        // Constructor para establecer la conexión a la base de datos
        public UsuarioDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para validar si el usuario existe con la contraseña proporcionada
        public bool ValidarUsuario(string email, string contraseña)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener la contraseña hasheada almacenada en la base de datos
                    string query = "SELECT Password FROM Usuarios WHERE Email = @Email";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        string storedHashedPassword = command.ExecuteScalar() as string;

                        // Verificar si la contraseña proporcionada coincide con la almacenada
                        if (storedHashedPassword != null && BCrypt.Net.BCrypt.Verify(contraseña, storedHashedPassword))
                        {
                            return true; // Contraseña válida
                        }
                        else
                        {
                            return false; // Contraseña incorrecta
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el usuario: " + ex.Message);
            }
        }

        // Método para verificar si un usuario con el correo electrónico ya existe
        public bool ExisteUsuario(string email)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    return (long)command.ExecuteScalar() > 0;
                }
            }
        }

        // Método para insertar un nuevo usuario con la contraseña hasheada
        public void InsertarUsuario(string email, string contraseña, string nombre)
        {
            // Hashear la contraseña antes de insertarla
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(contraseña);

            string query = "INSERT INTO usuarios (nombre, email, password) VALUES (@nombre, @Email, @Password)";

            // Crear y abrir una conexión
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open(); // Asegurarse de abrir la conexión

                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Agregar los parámetros al comando
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    // Ejecutar la consulta para insertar el nuevo usuario
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertarUsuarioGoogle(string email, string nombre)
        {
            string query = "INSERT INTO usuarios (nombre, email, password) VALUES (@nombre, @Email, NULL)";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerUserIdPorEmail(string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM usuarios WHERE email = @Email";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Retornar el ID del usuario
                        }
                        else
                        {
                            throw new Exception("Usuario no encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del usuario.", ex);
            }
        }

        public int ObtenerUserId(string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT id FROM usuarios WHERE email = @Email";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int userId))
                        {
                            return userId; // Retorna el userId encontrado
                        }

                        return 0; // Retorna 0 si no se encuentra el usuario
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el userId.", ex);
            }
        }

        public bool UsuarioExiste(int userId, string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta SQL para verificar si existe un usuario con el ID y el correo dados
                    string query = "SELECT COUNT(*) FROM usuarios WHERE id = @UserId AND email = @Email";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Email", email);

                        // Ejecutar la consulta y verificar si el conteo es mayor a 0
                        long count = (long)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si el usuario existe.", ex);
            }
        }
    }
}