using Microsoft.AspNetCore.Mvc;
using emergen_see_backend.Models;
using emergen_see_backend.Services;
using emergen_see_backend.DTOs;

namespace emergen_see_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor(DoctorDto doctorDto)
        {
            var createdDoctor = await _doctorService.CreateDoctorAsync(doctorDto);
            return CreatedAtAction(nameof(GetDoctor), new { id = createdDoctor.Id }, createdDoctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest();
            }

            await _doctorService.UpdateDoctorAsync(id, doctorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
