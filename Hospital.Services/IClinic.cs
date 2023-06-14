using Hospital.ViewModels;
using Hospital.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IClinic
    {
        PagedResults<ClinicViewModel> GetAll(int pageNumber, int pageSize);

        ClinicViewModel GetClinicById(int clinicId);
        void UpdateClinicInfo (ClinicViewModel clinic);
        void AddClinicInfo (ClinicViewModel clinic);
        void DeleteClinicInfo (int clinicId);
    }
}
