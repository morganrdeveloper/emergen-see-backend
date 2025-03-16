using AutoMapper;
using emergen_see_backend.Data;
using emergen_see_backend.DTOs;
using emergen_see_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emergen_see_backend.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> CreatePatientAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> UpdatePatientAsync(int id, PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
