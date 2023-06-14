using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IAppointment
    {
        PagedResults<AppointmentViewModel> GetAll(int pageNumber, int pageSize);

        AppointmentViewModel GetAppointmentById(int appId);
        void UpdateAppointmentInfo(AppointmentViewModel appointment);
        void AddAppointmentInfo(AppointmentViewModel appointment);
        void DeleteAppointmentInfo(int appId);
    }
}
