using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone_Donation_API.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
