using emergen_see_backend.DTOs;
using emergen_see_backend.Models;
using emergen_see_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace emergen_see_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(PatientDto patientDto)
        {
            var createdPatient = await _patientService.CreatePatientAsync(patientDto);
            return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest();
            }

            await _patientService.UpdatePatientAsync(id, patientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
