using HospitalAppointmentSystem.Models.Dtos;
using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repository;

namespace HospitalAppointmentSystem.Service
{
    public class AppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<Doctor> _doctorRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository, IRepository<Doctor> doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> CreateAppointment(Appointment appointmentDTO)
        {
            var doctor = await _doctorRepository.GetById(appointmentDTO.DoctorId);

            if (doctor == null || doctor.Patients.Count >= 10)
            {
                throw new Exception("Doctor is not available or has too many appointments.");
            }

            if (string.IsNullOrEmpty(appointmentDTO.PatientName))
            {
                throw new ArgumentException("Patient name cannot be empty.");
            }

            if (appointmentDTO.AppointmentDate < DateTime.Now.AddDays(3))
            {
                throw new ArgumentException("Appointment date must be at least 3 days in the future.");
            }

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                PatientName = appointmentDTO.PatientName,
                AppointmentDate = appointmentDTO.AppointmentDate,
                DoctorId = appointmentDTO.DoctorId
            };

            await _appointmentRepository.Add(appointment);
            return true;
        }

        // Expired appointments cleanup function
        public async Task DeleteExpiredAppointments()
        {
            var expiredAppointments = (await _appointmentRepository.GetAll())
                .Where(a => a.AppointmentDate < DateTime.Now).ToList();

            foreach (var appointment in expiredAppointments)
            {
                await _appointmentRepository.Delete(appointment.Id);
            }
        }
    }

}
