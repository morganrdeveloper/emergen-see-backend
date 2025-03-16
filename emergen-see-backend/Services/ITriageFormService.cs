using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface ITriageFormService
    {
        Task<IEnumerable<TriageForm>> GetAllTriageFormsAsync();
        Task<TriageForm> GetTriageFormByIdAsync(int id);
        Task<TriageForm> CreateTriageFormAsync(TriageForm triageForm);
        Task<TriageForm> UpdateTriageFormAsync(int id, TriageForm triageForm);
        Task DeleteTriageFormAsync(int id);
    }
}
