using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ClinicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ClinicViewModel()
        {

        }

        public ClinicViewModel(Clinic model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
        }

        public Clinic ConvertViewModel(ClinicViewModel model)
        {
            return new Clinic
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
