using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilites;
using Hospital.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class DoctorService : IDoctor
    {
        private IUnitOfWork _unitOfWork;
        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddDoctorInfo(DoctorViewModel doctor)
        {
            var model = new DoctorViewModel().ConvertViewModel(doctor);
            _unitOfWork.GenericRepository<Doctor>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteDoctorInfo(int docId)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(docId);
            _unitOfWork.GenericRepository<Doctor>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResults<DoctorViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new DoctorViewModel();
            int totalCount;
            List<DoctorViewModel> vmList = new List<DoctorViewModel>();
            try
            {
                int excludeRecords = (pageNumber * pageSize) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Doctor>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Doctor>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResults<DoctorViewModel>
            {
                Results = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public DoctorViewModel GetdoctorById(int docId)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(docId);
            var vm = new DoctorViewModel(model);
            return vm;
        }

        public void UpdateDoctorInfo(DoctorViewModel doctor)
        {
            var model = new DoctorViewModel().ConvertViewModel(doctor);
            var ModelById = _unitOfWork.GenericRepository<Doctor>().GetById(model.Id);
            ModelById.Name = doctor.Name;
            ModelById.Address = doctor.Address;
            ModelById.Phone = doctor.Phone;
            ModelById.Email = doctor.Email;
            ModelById.Password = doctor.Password;
            _unitOfWork.Save();
        }
        private List<DoctorViewModel> ConvertModelToViewModel(List<Doctor> modelList)
        {
            return modelList.Select(x => new DoctorViewModel(x)).ToList();
        }
    }
}
