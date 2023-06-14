using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public ICollection<Doctor> Doctors { get; set; }
    }
}
