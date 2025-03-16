using Microsoft.AspNetCore.Mvc;
using emergen_see_backend.Models;
using emergen_see_backend.Services;
using emergen_see_backend.DTOs;

namespace emergen_see_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueuesController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueueDto>>> GetQueues()
        {
            var queues = await _queueService.GetAllQueuesAsync();
            return Ok(queues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QueueDto>> GetQueue(int id)
        {
            var queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null)
            {
                return NotFound();
            }
            return Ok(queue);
        }

        [HttpPost]
        public async Task<ActionResult<QueueDto>> CreateQueue(QueueDto queueDto)
        {
            var createdQueue = await _queueService.CreateQueueAsync(queueDto);
            return CreatedAtAction(nameof(GetQueue), new { id = createdQueue.Id }, createdQueue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQueue(int id, QueueDto queueDto)
        {
            if (id != queueDto.Id)
            {
                return BadRequest();
            }

            await _queueService.UpdateQueueAsync(id, queueDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQueue(int id)
        {
            await _queueService.DeleteQueueAsync(id);
            return NoContent();
        }
    }
}
