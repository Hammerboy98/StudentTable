using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTOs;
using StudentTable.Models;

namespace StudentTable.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students.Select(s => new StudentResponseDTO
            {
                Id = s.Id,
                Nome = s.Nome,
                Cognome = s.Cognome,
                Email = s.Email
            }).ToList();
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return new StudentResponseDTO
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email
            };
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<StudentResponseDTO>> PostStudent(StudentRequestDTO studentDto)
        {
            var student = new Student
            {
                Nome = studentDto.Nome,
                Cognome = studentDto.Cognome,
                Email = studentDto.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var responseDto = new StudentResponseDTO
            {
                Id = student.Id,
                Nome = student.Nome,
                Cognome = student.Cognome,
                Email = student.Email
            };

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, responseDto);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentRequestDTO studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Nome = studentDto.Nome;
            student.Cognome = studentDto.Cognome;
            student.Email = studentDto.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
