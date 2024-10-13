using HospitalAppointmentSystem.Models;

public interface IAppointmentRepository
{
    Task<Appointment> Add(Appointment appointment);
    Task<Appointment> Delete(Guid id);
    Task<List<Appointment>> GetAll();
    Task<Appointment?> GetById(Guid id);
    Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId);
    Task<Appointment> Update(Appointment appointment);
}
