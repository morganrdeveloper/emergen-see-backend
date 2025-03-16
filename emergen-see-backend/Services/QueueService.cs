using AutoMapper;
using emergen_see_backend.Data;
using emergen_see_backend.DTOs;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emergen_see_backend.Services
{
    public class QueueService : IQueueService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QueueService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QueueDto>> GetAllQueuesAsync()
        {
            var queues = await _context.Queues.ToListAsync();
            return _mapper.Map<IEnumerable<QueueDto>>(queues);
        }

        public async Task<QueueDto> GetQueueByIdAsync(int id)
        {
            var queue = await _context.Queues.FindAsync(id);
            return _mapper.Map<QueueDto>(queue);
        }

        public async Task<QueueDto> CreateQueueAsync(QueueDto queueDto)
        {
            var queue = _mapper.Map<Queue>(queueDto);
            _context.Queues.Add(queue);
            await _context.SaveChangesAsync();
            return _mapper.Map<QueueDto>(queue);
        }

        public async Task<QueueDto> UpdateQueueAsync(int id, QueueDto queueDto)
        {
            var queue = _mapper.Map<Queue>(queueDto);
            _context.Entry(queue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<QueueDto>(queue);
        }

        public async Task DeleteQueueAsync(int id)
        {
            var queue = await _context.Queues.FindAsync(id);
            if (queue != null)
            {
                _context.Queues.Remove(queue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
