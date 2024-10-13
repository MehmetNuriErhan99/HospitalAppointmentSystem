using HospitalAppointmentSystem.Models.Enums;

namespace HospitalAppointmentSystem.Models.Dtos;

public class DoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Branch Branch { get; set; }
}
