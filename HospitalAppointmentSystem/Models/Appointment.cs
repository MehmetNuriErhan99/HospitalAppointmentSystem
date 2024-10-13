namespace HospitalAppointmentSystem.Models;

public sealed  class Appointment : Entity <Guid>
{

    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } 

    public Appointment(string patientName, DateTime appointmentDate, int doctorId)
    {
        PatientName = patientName;
        AppointmentDate = appointmentDate;
        DoctorId = doctorId;
    }
}
