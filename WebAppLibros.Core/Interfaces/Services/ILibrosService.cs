using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLibros.Core.Entities;

namespace WebAppLibros.Core.Interfaces.Services
{
    public interface ILibrosService
    {
        Task<Libros> GetClassroomById(int id);
        Task<IEnumerable<Libros>> GetAll();
        Task<Libros> CreateClassroom(Libros newLibros);
        Task<Libros> UpdateClassroom(int librosToBeUpdatedId, Libros newLibrosValues);
        Task DeleteClassroom(int librosId);
    }
}
