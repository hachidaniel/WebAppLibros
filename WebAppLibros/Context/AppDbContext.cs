using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAppLibros.Models;

namespace WebAppLibros.Context
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
            Database.EnsureCreated();
        }
        public DbSet<Libros> Libros { get; set; }
    }
}
