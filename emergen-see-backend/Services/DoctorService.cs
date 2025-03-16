using AutoMapper;
using emergen_see_backend.Data;
using emergen_see_backend.DTOs;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emergen_see_backend.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<DoctorDto> CreateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<DoctorDto> UpdateDoctorAsync(int id, DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
