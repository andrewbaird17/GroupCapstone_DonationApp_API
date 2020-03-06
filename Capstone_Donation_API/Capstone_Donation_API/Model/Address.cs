using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_Donation_API.Model
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
