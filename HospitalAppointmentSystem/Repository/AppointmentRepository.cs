using HospitalAppointmentSystem.Models;
using System;

namespace HospitalAppointmentSystem.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Add(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var appointment = await GetById(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Guid ıd)
        {
            throw new NotImplementedException();
        }
    }

}
