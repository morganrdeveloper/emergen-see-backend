using Microsoft.AspNetCore.Mvc;
using emergen_see_backend.DTOs;
using emergen_see_backend.Services;

namespace emergen_see_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriageFormsController : ControllerBase
    {
        private readonly ITriageFormService _triageFormService;

        public TriageFormsController(ITriageFormService triageFormService)
        {
            _triageFormService = triageFormService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TriageFormDto>>> GetTriageForms()
        {
            var triageForms = await _triageFormService.GetAllTriageFormsAsync();
            return Ok(triageForms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TriageFormDto>> GetTriageForm(int id)
        {
            var triageForm = await _triageFormService.GetTriageFormByIdAsync(id);
            if (triageForm == null)
            {
                return NotFound();
            }
            return Ok(triageForm);
        }

        [HttpPost]
        public async Task<ActionResult<TriageFormDto>> CreateTriageForm(TriageFormDto triageFormDto)
        {
            var createdTriageForm = await _triageFormService.CreateTriageFormAsync(triageFormDto);
            return CreatedAtAction(nameof(GetTriageForm), new { id = createdTriageForm.Id }, createdTriageForm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTriageForm(int id, TriageFormDto triageFormDto)
        {
            if (id != triageFormDto.Id)
            {
                return BadRequest();
            }

            await _triageFormService.UpdateTriageFormAsync(id, triageFormDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTriageForm(int id)
        {
            await _triageFormService.DeleteTriageFormAsync(id);
            return NoContent();
        }
    }
}
