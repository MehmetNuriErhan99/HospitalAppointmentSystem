using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repository.Abstract;

namespace HospitalAppointmentSystem.Service.Concretes
{
    public class AppointmentService: IAppointmentService
    private IAppointmentRepository _appointmentRepository;
    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public Appointment AddAppointment(Appointment user)
    {
        return _appointmentRepository.Add(user);
    }

    public Appointment DeleteAppointment(Guid id)
    {
        return _appointmentRepository.Delete(id);
    }

    public List<Appointment> GetAllAppointments()
    {
        return _appointmentRepository.GetAll();
    }

    public Appointment? GetAppointmentById(Guid id)
    {
        return _appointmentRepository.GetById(id);
    }

    public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
    {
        return _appointmentRepository.GetAppointmentsByDoctorId(doctorId);
    }

    public Appointment UpdateAppointment(Appointment user)
    {
        return _appointmentRepository.Update(user);
    }
}

