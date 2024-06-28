using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppLibros.Core.Entities;
using WebAppLibros.Core.Interfaces.Services;

namespace WebAppLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly ILibrosService _librosService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public LibrosController(ILibrosService librosService, IMapper mapper )
        {
            _librosService = librosService;
            _mapper = mapper;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            var classrooms =
                        await _librosService.GetAll();

            var mappedClassrooms =
                        _mapper.Map<IEnumerable<Core.Entities.Libros>, IEnumerable<Core.Entities.Libros>>(classrooms);

            return Ok(mappedClassrooms);
        }

       // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibros(int id)
        {
            var classroom = await _librosService.GetClassroomById(id);
            var mappedClassroom =
                _mapper.Map<Core.Entities.Libros, Core.Entities.Libros>(classroom);
            return Ok(mappedClassroom);
        }

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Core.Entities.Libros>> PostLibros([FromBody]  Core.Entities.Libros libros)
        {
            try
            {
                var createdClassroom =
                    await _librosService.CreateClassroom(_mapper.Map<Core.Entities.Libros, Core.Entities.Libros>(libros));

                return Ok(_mapper.Map<Core.Entities.Libros, Core.Entities.Libros>(createdClassroom));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, [FromBody] Core.Entities.Libros libros)
        {
            try
            {
                var updatedClassroom =
                    await _librosService.UpdateClassroom(id, _mapper.Map<Core.Entities.Libros, Core.Entities.Libros>(libros));

                return Ok(_mapper.Map<Core.Entities.Libros, Core.Entities.Libros>(updatedClassroom));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibros(int id)
        {
            var libros = _librosService.DeleteClassroom(id);
            if (libros == null)
            {
                return NotFound();
            }

            return Ok(libros);
        }
    }
}
