using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Entities;
using WebAppLibros.Core.Interfaces.Repositories;
using WebAppLibros.Infrastructure.Data;

namespace WebAppLibros.Infrastructure.Repositories
{
    public class LibrosRepository : BaseRepository<Libros>, ILibrosRepository
    {
        public LibrosRepository(AppDbContext context) : base(context)
        {
        }
    }
}
