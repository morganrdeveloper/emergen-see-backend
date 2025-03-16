using emergen_see_backend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emergen_see_backend.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(PatientDto patientDto);
        Task<PatientDto> UpdatePatientAsync(int id, PatientDto patientDto);
        Task DeletePatientAsync(int id);
    }
}
