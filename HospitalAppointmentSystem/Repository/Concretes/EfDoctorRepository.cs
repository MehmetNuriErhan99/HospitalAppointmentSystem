using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Enums;
using HospitalAppointmentSystem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalAppointmentSystem.Repository.Concretes
{
    public class EfDoctorRepository : IDoctorRepository
    {
        private readonly HospitalContext _context;

        public EfDoctorRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task Add(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetById(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public List<Doctor> GetDoctorsByBranch(Branch branch)
        {
            return _context.Doctors.Where(d => d.Branch == branch).ToList();
        }
    }
}
    