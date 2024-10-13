namespace HospitalAppointmentSystem.Models.Dtos;

public class AppointmentDto
{
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
    
}
