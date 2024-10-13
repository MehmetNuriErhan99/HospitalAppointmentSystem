using HospitalAppointmentSystem.Models.Enums;

namespace HospitalAppointmentSystem.Models;

public sealed  class Appointment : Entity <Guid>
{
    public static int Count { get; internal set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }


}
