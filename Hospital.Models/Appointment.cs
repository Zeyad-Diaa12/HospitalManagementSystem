using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Appointment
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
    }
}
