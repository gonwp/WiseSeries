using Entidades;
using Npgsql;
using System.Xml.Linq;

namespace CapaDatos
{
    public class AnimeDAL
    {
        private readonly string connectionString;

        public AnimeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Anime> ObtenerAnimes(int userId)
        {
            try
            {
                // Verificar que la cadena de conexión no esté vacía
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("La cadena de conexión no es válida.");
                }

                // Consulta SQL para obtener los animes del usuario
                using (var connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new Npgsql.NpgsqlCommand("SELECT * FROM animes WHERE user_id = @userId", connection);
                    command.Parameters.AddWithValue("@userId", userId);
                    var reader = command.ExecuteReader();

                    List<Anime> animes = new List<Anime>();
                    while (reader.Read())
                    {
                        animes.Add(new Anime
                        {
                            Id = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Genero = reader.GetString(2),
                            Episodio = reader.GetInt32(3),
                            Temporada = reader.GetInt32(4),
                            Completado = reader.GetBoolean(5),
                            UserId = reader.GetInt32(6)
                        });
                    }

                    // Si no hay animes, simplemente devolver una lista vacía
                    return animes;
                }
            }
            catch (Npgsql.NpgsqlException ex)
            {
                // Manejo de excepciones específicas de PostgreSQL
                throw new Exception($"Error de base de datos al obtener los animes para el usuario con ID {userId}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                throw new Exception($"Error al obtener los animes para el usuario con ID {userId}: {ex.Message}", ex);
            }
        }

        // Insertar un nuevo anime asociado a un usuario
        public void InsertarAnime(Anime anime, int userId)
        {
            try
            {
                // Validar datos antes de intentar insertarlos en la base de datos
                if (string.IsNullOrWhiteSpace(anime.Titulo))
                {
                    throw new ArgumentException("El título del anime no puede estar vacío o solo contener espacios en blanco.");
                }

                if (anime.Episodio < 0)
                {
                    throw new ArgumentException("El número de episodios no puede ser negativo.");
                }

                if (anime.Temporada < 0)
                {
                    throw new ArgumentException("El número de temporadas no puede ser negativo.");
                }

                if (userId <= 0)
                {
                    throw new ArgumentException("El userId debe ser un número positivo válido.");
                }

                // Intentar la conexión e inserción
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open(); // Asegurarse de que la conexión está abierta

                    string query = "INSERT INTO animes (titulo, genero, episodio, temporada, completado, user_id) " +
                                   "VALUES (@titulo, @genero, @episodio, @temporada, @completado, @userId)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Agregar los parámetros de manera segura
                        command.Parameters.AddWithValue("@titulo", anime.Titulo);
                        command.Parameters.AddWithValue("@genero", string.IsNullOrWhiteSpace(anime.Genero) ? (object)DBNull.Value : anime.Genero);
                        command.Parameters.AddWithValue("@episodio", anime.Episodio);
                        command.Parameters.AddWithValue("@temporada", anime.Temporada);
                        command.Parameters.AddWithValue("@completado", anime.Completado);
                        command.Parameters.AddWithValue("@userId", userId);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (ArgumentException argEx)
            {
                // Manejo de errores específicos de validación
                throw new Exception($"Error de validación: {argEx.Message}", argEx);
            }
            catch (NpgsqlException npgsqlEx)
            {
                // Manejo de errores relacionados con PostgreSQL
                throw new Exception($"Error al ejecutar la consulta en la base de datos: {npgsqlEx.Message}", npgsqlEx);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error general
                throw new Exception("Error al insertar el anime en la base de datos.", ex);
            }
        }

        // Eliminar un anime asociado a un usuario específico
        public void EliminarAnime(int id, int userId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM animes WHERE id = @id AND user_id = @userId"; // Validar que el anime pertenece al usuario
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@userId", userId); // Asociar el anime con el usuario

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el anime de la base de datos.", ex);
            }
        }

        // Actualizar un anime asociado a un usuario específico
        public void ActualizarAnime(Anime anime, int userId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE animes SET titulo = @titulo, genero = @genero, episodio = @episodio, " +
                                   "temporada = @temporada, completado = @completado WHERE id = @id AND user_id = @userId";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@titulo", anime.Titulo);
                        command.Parameters.AddWithValue("@genero", anime.Genero);
                        command.Parameters.AddWithValue("@episodio", anime.Episodio);
                        command.Parameters.AddWithValue("@temporada", anime.Temporada);
                        command.Parameters.AddWithValue("@completado", anime.Completado);
                        command.Parameters.AddWithValue("@id", anime.Id);
                        command.Parameters.AddWithValue("@userId", userId); // Validar que el anime pertenece al usuario

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el anime en la base de datos.", ex);
            }
        }

        // Obtener todos los géneros disponibles
        public List<string> ObtenerGeneros()
        {
            List<string> generos = new List<string>();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre FROM generos";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            generos.Add(reader["nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los géneros de la base de datos.", ex);
            }

            return generos;
        }
    }
}