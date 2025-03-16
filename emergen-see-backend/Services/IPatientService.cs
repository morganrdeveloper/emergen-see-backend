using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(int id, Patient patient);
        Task DeletePatientAsync(int id);
    }
}
