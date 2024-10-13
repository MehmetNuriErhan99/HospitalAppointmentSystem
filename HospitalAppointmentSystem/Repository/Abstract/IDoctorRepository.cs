using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Models.Enums;


namespace HospitalAppointmentSystem.Repository.Abstract;

public interface IDoctorRepository : IRepository<Doctor, int>
{
    List<Doctor> GetDoctorsByBranch(Branch branch);
}
