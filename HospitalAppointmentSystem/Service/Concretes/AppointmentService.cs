using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalAppointmentSystem.Service.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            // Randevu tarihi kontrolü (örneğin 3 gün sonrası)
            if (appointment.AppointmentDate < DateTime.Now.AddDays(3))
                throw new ArgumentException("Randevu tarihi en az 3 gün sonrası olmalıdır.");

            return await _appointmentRepository.Add(appointment);
        }

        public async Task<Appointment> DeleteAppointment(Guid id)
        {
            return await _appointmentRepository.Delete(id);
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAll();
        }

        public async Task<Appointment?> GetAppointmentById(Guid id)
        {
            return await _appointmentRepository.GetById(id);
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId)
        {
            return await _appointmentRepository.GetAppointmentsByDoctorId(doctorId);
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            return await _appointmentRepository.Update(appointment);
        }
    }
}
