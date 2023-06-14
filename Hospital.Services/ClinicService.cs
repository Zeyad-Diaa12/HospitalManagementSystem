using Hospital.Repositories.Interfaces;
using Hospital.Utilites;
using Hospital.Models;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ClinicService : IClinic
    {
        private IUnitOfWork _unitOfWork;
        public ClinicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddClinicInfo(ClinicViewModel clinic)
        {
            var model = new ClinicViewModel().ConvertViewModel(clinic);
            _unitOfWork.GenericRepository<Clinic>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteClinicInfo(int clinicId)
        {
            var model = _unitOfWork.GenericRepository<Clinic>().GetById(clinicId);
            _unitOfWork.GenericRepository<Clinic>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResults<ClinicViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ClinicViewModel();
            int totalCount;
            List<ClinicViewModel> vmList = new List<ClinicViewModel>();
            try
            {
                int excludeRecords = (pageNumber * pageSize) - pageSize;
                
                var modelList = _unitOfWork.GenericRepository<Clinic>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Clinic>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModel(modelList); 
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResults<ClinicViewModel>
            {
                Results = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public ClinicViewModel GetClinicById(int clinicId)
        {
            var model = _unitOfWork.GenericRepository<Clinic>().GetById(clinicId);
            var vm = new ClinicViewModel(model);
            return vm;
        }

        public void UpdateClinicInfo(ClinicViewModel clinic)
        {
            var model = new ClinicViewModel().ConvertViewModel(clinic);
            var ModelById = _unitOfWork.GenericRepository<Clinic>().GetById(model.Id);
            ModelById.Name = clinic.Name;
            ModelById.Description = clinic.Description;
            _unitOfWork.Save();
        }

        private List<ClinicViewModel> ConvertModelToViewModel (List<Clinic> modelList)
        {
            return modelList.Select(x => new ClinicViewModel(x)).ToList();
        }
    }
}
