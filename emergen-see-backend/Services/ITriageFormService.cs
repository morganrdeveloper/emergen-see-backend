using emergen_see_backend.DTOs;
using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface ITriageFormService
    {
        Task<IEnumerable<TriageFormDto>> GetAllTriageFormsAsync();
        Task<TriageFormDto> GetTriageFormByIdAsync(int id);
        Task<TriageFormDto> CreateTriageFormAsync(TriageFormDto triageFormDto);
        Task<TriageFormDto> UpdateTriageFormAsync(int id, TriageFormDto triageFormDto);
        Task DeleteTriageFormAsync(int id);
    }
}
