using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone_Donation_API.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("MedicalHistory")]
        public int? MedicalId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string IdentityUserId { get; set; }

    }
}
