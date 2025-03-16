using Microsoft.AspNetCore.Mvc;
using emergen_see_backend.Models;
using emergen_see_backend.Services;

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
        public async Task<ActionResult<IEnumerable<Queue>>> GetQueues()
        {
            var queues = await _queueService.GetAllQueuesAsync();
            return Ok(queues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Queue>> GetQueue(int id)
        {
            var queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null)
            {
                return NotFound();
            }
            return Ok(queue);
        }

        [HttpPost]
        public async Task<ActionResult<Queue>> CreateQueue(Queue queue)
        {
            var createdQueue = await _queueService.CreateQueueAsync(queue);
            return CreatedAtAction(nameof(GetQueue), new { id = createdQueue.Id }, createdQueue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQueue(int id, Queue queue)
        {
            if (id != queue.Id)
            {
                return BadRequest();
            }

            await _queueService.UpdateQueueAsync(id, queue);
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
