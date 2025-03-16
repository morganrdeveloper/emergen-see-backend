using emergen_see_backend.Data;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace emergen_see_backend.Services
{
    public class TriageFormService : ITriageFormService
    {
        private readonly ApplicationDbContext _context;

        public TriageFormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TriageForm>> GetAllTriageFormsAsync()
        {
            return await _context.TriageForms.ToListAsync();
        }

        public async Task<TriageForm> GetTriageFormByIdAsync(int id)
        {
            return await _context.TriageForms.FindAsync(id);
        }

        public async Task<TriageForm> CreateTriageFormAsync(TriageForm triageForm)
        {
            _context.TriageForms.Add(triageForm);
            await _context.SaveChangesAsync();
            return triageForm;
        }

        public async Task<TriageForm> UpdateTriageFormAsync(int id, TriageForm triageForm)
        {
            _context.Entry(triageForm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return triageForm;
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
