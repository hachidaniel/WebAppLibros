using Microsoft.EntityFrameworkCore;
using WebAppLibros.Models;

namespace WebAppLibros.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Libros> Libros { get; set; }
    }
}
