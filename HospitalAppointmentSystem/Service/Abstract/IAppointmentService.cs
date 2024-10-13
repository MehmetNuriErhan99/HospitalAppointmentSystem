using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Service.Abstract
{


    public interface IAppointmentService
    {
        Appointment? GetAppointmentById(Guid id);
        List<Appointment> GetAllAppointments();

        Appointment AddAppointment(Appointment user);
        Appointment UpdateAppointment(Appointment user);
        Appointment DeleteAppointment(Guid id);
        List<Appointment> GetAppointmentsByDoctorId(int doctorId);
    }
}