using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repository.Abstract;

namespace HospitalAppointmentSystem.Service.Abstract
{
    public interface IDoctorService
    {
        Doctor? GetDoctorById(int id);
        List<Doctor> GetAllDoctors();

        Doctor AddDoctor(Doctor user);
        Doctor UpdateDoctor(Doctor user);
        Doctor DeleteDoctor(int id);
        List<Doctor> GetDoctorsByBranch(BranchType branch);
    }
}
