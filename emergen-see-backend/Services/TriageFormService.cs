using AutoMapper;
using emergen_see_backend.Data;
using emergen_see_backend.DTOs;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emergen_see_backend.Services
{
    public class TriageFormService : ITriageFormService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TriageFormService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TriageFormDto>> GetAllTriageFormsAsync()
        {
            var triageForms = await _context.TriageForms.ToListAsync();
            return _mapper.Map<IEnumerable<TriageFormDto>>(triageForms);
        }

        public async Task<TriageFormDto> GetTriageFormByIdAsync(int id)
        {
            var triageForm = await _context.TriageForms.FindAsync(id);
            return _mapper.Map<TriageFormDto>(triageForm);
        }

        public async Task<TriageFormDto> CreateTriageFormAsync(TriageFormDto triageFormDto)
        {
            var triageForm = _mapper.Map<TriageForm>(triageFormDto);
            _context.TriageForms.Add(triageForm);
            await _context.SaveChangesAsync();
            return _mapper.Map<TriageFormDto>(triageForm);
        }

        public async Task<TriageFormDto> UpdateTriageFormAsync(int id, TriageFormDto triageFormDto)
        {
            var triageForm = _mapper.Map<TriageForm>(triageFormDto);
            _context.Entry(triageForm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<TriageFormDto>(triageForm);
        }

        public async Task DeleteTriageFormAsync(int id)
        {
            var triageForm = await _context.TriageForms.FindAsync(id);
            if (triageForm != null)
            {
                _context.TriageForms.Remove(triageForm);
                await _context.SaveChangesAsync();
            }
        }
    }
}
