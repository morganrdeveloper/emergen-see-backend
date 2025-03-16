using emergen_see_backend.DTOs;
using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorByIdAsync(int id);
        Task<DoctorDto> CreateDoctorAsync(DoctorDto doctorDto);
        Task<DoctorDto> UpdateDoctorAsync(int id, DoctorDto doctorDto);
        Task DeleteDoctorAsync(int id);
    }
}
