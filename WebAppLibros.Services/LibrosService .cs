using WebAppLibros.Core.Entities;
using WebAppLibros.Core.Interfaces;
using WebAppLibros.Core.Interfaces.Services;
using WebAppLibros.Services.Validators;

namespace WebAppLibros.Services
{
    public class LibrosService : ILibrosService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LibrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Libros> CreateClassroom(Libros newClassroom)
        {
            LibrosValidator validator = new();

            var validationResult = await validator.ValidateAsync(newClassroom);
            if (validationResult.IsValid)
            {
                await _unitOfWork.LibrosRepository.AddAsync(newClassroom);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newClassroom;
        }

        public async Task DeleteClassroom(int classroomId)
        {
            Libros classroom = await _unitOfWork.LibrosRepository.GetByIdAsync(classroomId);
            _unitOfWork.LibrosRepository.Remove(classroom);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Libros>> GetAll()
        {
            return await _unitOfWork.LibrosRepository.GetAllAsync();
        }

        public async Task<Libros> GetClassroomById(int id)
        {
            return await _unitOfWork.LibrosRepository.GetByIdAsync(id);
        }

        public async Task<Libros> UpdateClassroom(int classroomToBeUpdatedId, Libros newClassroomValues)
        {
            LibrosValidator classroomValidator = new();

            var validationResult = await classroomValidator.ValidateAsync(newClassroomValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Libros classroomToBeUpdated = await _unitOfWork.LibrosRepository.GetByIdAsync(classroomToBeUpdatedId);

            if (classroomToBeUpdated == null)
                throw new ArgumentException("Invalid classroom ID while updating");

            classroomToBeUpdated.Name = newClassroomValues.Name;
            classroomToBeUpdated.Description = newClassroomValues.Description;
            classroomToBeUpdated.Title = newClassroomValues.Title;
            classroomToBeUpdated.Count = newClassroomValues.Count;
            classroomToBeUpdated.Url = newClassroomValues.Url;
            classroomToBeUpdated.IsDeleted = newClassroomValues.IsDeleted;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.LibrosRepository.GetByIdAsync(classroomToBeUpdatedId);
        }
    }
}
