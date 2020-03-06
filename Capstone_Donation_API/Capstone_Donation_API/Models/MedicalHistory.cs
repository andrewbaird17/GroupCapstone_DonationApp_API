using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Donation_API.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedicalId {get; set;}
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string BloodType { get; set; }
        public bool OnMedications { get; set; }
        public bool HasAllergies { get; set; }
        public bool IsMale { get; set; }
        public string Ethnicity { get; set; }


    }
}
