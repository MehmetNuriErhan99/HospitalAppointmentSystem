using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Repository.Abstract;

public interface IAppointmentRepository : IRepository<Appointment, Guid>
{
    List<Appointment> GetAppointmentsByDoctorId(int doctorId);
}
