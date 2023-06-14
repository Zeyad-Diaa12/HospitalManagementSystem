using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public DoctorViewModel()
        {

        }

        public DoctorViewModel(Doctor model)
        {
            Id = model.Id;
            Name = model.Name;
            Gender = model.Gender;
            Nationality = model.Nationality;
            DOB = model.DOB;
            Specialist = model.Specialist;
            Email = model.Email;
            Phone = model.Phone;
            Password = model.Password;
            Address = model.Address;
        }

        public Doctor ConvertViewModel(DoctorViewModel model)
        {
            return new Doctor
            {
                Id = model.Id,
                Name = model.Name,
                Gender = model.Gender,
                Nationality = model.Nationality,
                DOB = model.DOB,
                Specialist = model.Specialist,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
                Address = model.Address
            };
        }
    }
}
