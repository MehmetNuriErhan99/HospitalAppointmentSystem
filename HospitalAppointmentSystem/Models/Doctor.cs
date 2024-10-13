using HospitalAppointmentSystem.Models.Enums;

namespace HospitalAppointmentSystem.Models;

public sealed class Doctor : Entity <int>


   
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch Branch { get; set; } // Enum

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }




