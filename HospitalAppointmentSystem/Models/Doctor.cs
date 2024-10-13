using HospitalAppointmentSystem.Models.Enums;

namespace HospitalAppointmentSystem.Models;

public sealed class Doctor : Entity <int>
{

    public string Name { get; set; }
    public Branch Branch { get; set; } // Enum for branch
    public List<Appointment> Patients { get; set; } = new List<Appointment>();


       
        public Doctor(int id, string name, Branch branch)
        {
            Id = id;
            Name = name;
            Branch = branch;
        }



}



