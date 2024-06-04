namespace WebAppLibros.Models
{
    public class Libros
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public required string Title { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
    }
}
