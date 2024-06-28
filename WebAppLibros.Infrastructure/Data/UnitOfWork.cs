using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Interfaces;
using WebAppLibros.Core.Interfaces.Repositories;
using WebAppLibros.Infrastructure.Repositories;

namespace WebAppLibros.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private LibrosRepository _librosRepository;

        public ILibrosRepository LibrosRepository => _librosRepository ??= new LibrosRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
