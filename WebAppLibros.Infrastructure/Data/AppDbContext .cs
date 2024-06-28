using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Entities;
using WebAppLibros.Infrastructure.Data.Configurations;

namespace WebAppLibros.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Libros> Libros { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LibrosConfiguration());
        }
    }
}
