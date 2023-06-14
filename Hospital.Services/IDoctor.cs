using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IDoctor
    {
        PagedResults<DoctorViewModel> GetAll(int pageNumber, int pageSize);

        DoctorViewModel GetdoctorById(int docId);
        void UpdateDoctorInfo(DoctorViewModel doctor);
        void AddDoctorInfo(DoctorViewModel doctor);
        void DeleteDoctorInfo(int docId);
    }
}
