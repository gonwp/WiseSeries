using CapaDatos;
using Entidades;

namespace CapaNegocios
{
    public class AnimeBL
    {
        private readonly AnimeDAL _animeDAL;

        public AnimeBL(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula o vacía.");
            }

            _animeDAL = new AnimeDAL(connectionString);
        }

        // Obtener animes de un usuario específico
        public List<Anime> ObtenerAnimes(int userId)
        {
            // Validar que el userId es válido
            if (userId <= 0)
            {
                // Si el ID de usuario no es válido, retornar una lista vacía
                return new List<Anime>();
            }

            try
            {
                // Obtener los animes desde la capa de acceso a datos
                var animes = _animeDAL.ObtenerAnimes(userId);

                // Si no hay animes, devuelve una lista vacía
                return animes ?? new List<Anime>(); // Asegura que nunca retornemos null
            }
            catch (Exception ex)
            {
                // Si ocurre cualquier tipo de error, lanzar una excepción genérica con detalles
                throw new Exception($"Error inesperado al obtener los animes para el usuario con ID {userId}. Detalles: {ex.Message}", ex);
            }
        }

        // Guardar un anime para un usuario específico
        public void GuardarAnime(Anime anime, int userId)
        {
            if (anime == null)
            {
                throw new ArgumentNullException(nameof(anime), "El objeto anime no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(anime.Titulo))
            {
                throw new ArgumentException("El título del anime es obligatorio.", nameof(anime.Titulo));
            }

            if (userId <= 0)
            {
                throw new ArgumentException("El ID de usuario debe ser mayor a cero.", nameof(userId));
            }

            try
            {
                _animeDAL.InsertarAnime(anime, userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al guardar el anime '{anime.Titulo}' para el usuario con ID {userId}.", ex);
            }
        }

        // Eliminar un anime para un usuario específico
        public void EliminarAnime(int id, int userId)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del anime debe ser mayor a cero.", nameof(id));
            }

            if (userId <= 0)
            {
                throw new ArgumentException("El ID de usuario debe ser mayor a cero.", nameof(userId));
            }

            try
            {
                _animeDAL.EliminarAnime(id, userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar el anime con ID {id} para el usuario con ID {userId}.", ex);
            }
        }

        // Actualizar un anime para un usuario específico
        public void ActualizarAnime(Anime anime, int userId)
        {
            if (anime == null)
            {
                throw new ArgumentNullException(nameof(anime), "El objeto anime no puede ser nulo.");
            }

            if (userId <= 0)
            {
                throw new ArgumentException("El ID de usuario debe ser mayor a cero.", nameof(userId));
            }

            try
            {
                _animeDAL.ActualizarAnime(anime, userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar el anime '{anime.Titulo}' con ID {anime.Id} para el usuario con ID {userId}.", ex);
            }
        }
    }
}