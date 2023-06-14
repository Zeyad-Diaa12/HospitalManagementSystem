using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
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
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }

    }
}

