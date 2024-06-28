using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Interfaces.Repositories;

namespace WebAppLibros.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILibrosRepository LibrosRepository { get; }
        Task<int> CommitAsync();
    }
}
