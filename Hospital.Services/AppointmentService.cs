using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilites;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class AppointmentService : IAppointment
    {
        private IUnitOfWork _unitOfWork;
        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAppointmentInfo(AppointmentViewModel appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(appointment);
            _unitOfWork.GenericRepository<Appointment>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteAppointmentInfo(int appId)
        {
            var model = _unitOfWork.GenericRepository<Appointment>().GetById(appId);
            _unitOfWork.GenericRepository<Appointment>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResults<AppointmentViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> vmList = new List<AppointmentViewModel>();
            try
            {
                int excludeRecords = (pageNumber * pageSize) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResults<AppointmentViewModel>
            {
                Results = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public AppointmentViewModel GetAppointmentById(int appId)
        {
            var model = _unitOfWork.GenericRepository<Appointment>().GetById(appId);
            var vm = new AppointmentViewModel(model);
            return vm;
        }

        public void UpdateAppointmentInfo(AppointmentViewModel appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(appointment);
            var ModelById = _unitOfWork.GenericRepository<Appointment>().GetById(model.Id);
            ModelById.Title = appointment.Title;
            ModelById.Description = appointment.Description;
            ModelById.Createddate = appointment.Createddate;
            ModelById.Patient = appointment.Patient;
            ModelById.Number = appointment.Number;
            ModelById.Doctor = appointment.Doctor;
            _unitOfWork.Save();
        }

        private List<AppointmentViewModel> ConvertModelToViewModel(List<Appointment> modelList)
        {
            return modelList.Select(x => new AppointmentViewModel(x)).ToList();
        }
    }
}
