using Hospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTime Createddate { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        [NotMapped]
        public AppUser Patient { get; set; }

        public AppointmentViewModel()
        {

        }

        public AppointmentViewModel(Appointment model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            Createddate = model.Createddate;
            Patient = model.Patient;
            Number = model.Number;
            Doctor = model.Doctor;
        }

        public Appointment ConvertViewModel(AppointmentViewModel model)
        {
            return new Appointment
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Createddate = model.Createddate,
                Patient = model.Patient,
                Number = model.Number,
                Doctor = model.Doctor
            };
        }
    }
}
