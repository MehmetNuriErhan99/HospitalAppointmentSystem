using HospitalAppointmentSystem.Models;
using HospitalAppointmentSystem.Repository.Abstract;

namespace HospitalAppointmentSystem.Service.Concretes
{


    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Doctor AddDoctor(Doctor user)
        {
            return _doctorRepository.Add(user);
        }

        public Doctor DeleteDoctor(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor? GetDoctorById(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public List<Doctor> GetDoctorsByBranch(BranchType branch)
        {
            return _doctorRepository.GetDoctorsByBranch(branch);
        }

        public Doctor UpdateDoctor(Doctor user)
        {
            return _doctorRepository.Update(user);
        }
    }
}