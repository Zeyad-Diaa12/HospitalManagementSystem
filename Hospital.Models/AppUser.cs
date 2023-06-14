using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
    }
}

namespace Hospital.Models
{
    public enum Gender{
        Male,
        Female
    }
}
