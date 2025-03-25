using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTOs;
using StudentTable.Models;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StudentProfileResponseDTO>> PostStudentProfile(StudentProfileRequestDTO profileDto)
        {
            var profile = new StudentProfile
            {
                FirstName = profileDto.FirstName,
                LastName = profileDto.LastName,
                FiscalCode = profileDto.FiscalCode,
                BirthDate = profileDto.BirthDate,
                StudentId = profileDto.StudentId
            };

            _context.StudentProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return new StudentProfileResponseDTO
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                FiscalCode = profile.FiscalCode,
                BirthDate = profile.BirthDate
            };
        }
    }
}
