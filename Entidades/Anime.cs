namespace Entidades
{
    public class Anime
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Episodio { get; set; }
        public int Temporada { get; set; }
        public bool Completado { get; set; }
        public int UserId { get; set; }
    }
}