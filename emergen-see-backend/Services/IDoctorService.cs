using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }
}
