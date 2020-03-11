using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Capstone_Donation_API.Data;
using Capstone_Donation_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Donation_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private ApplicationContext _context;

        public DonorController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Donor> Get()
        {
            var donorArray = _context.Donors.Include("Address").Include("MedicalHistory").ToArray();
            return donorArray;
        }

        [HttpGet("{id}")]
        public Donor Get(int id)
        {
            var donor = _context.Donors.Include("Address").Include("MedicalHistory").Where(d => d.Id == id).FirstOrDefault();
            return donor;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Donor donor)
        {
            _context.Donors.Add(donor);
            _context.SaveChanges();
            return Ok(donor);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Donor donor)
        {
            var donorinDB = _context.Donors.Where(d => d.IdentityUserId == donor.IdentityUserId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                donorinDB.FirstName = donor.FirstName;
                donorinDB.LastName = donor.LastName;
                if (donorinDB.AddressId == null)
                {
                    Address newAddress = new Address();
                    newAddress = donor.Address;
                    _context.Addresses.Add(newAddress);
                    _context.SaveChanges();
                    var addressInDB = _context.Addresses.Where(a => a.StreetAddress == donor.Address.StreetAddress).Where(a => a.City == donor.Address.City)
                        .Where(a => a.State == donor.Address.State).Where(a => a.ZipCode == donor.Address.ZipCode).FirstOrDefault();
                    donorinDB.AddressId = addressInDB.Id;
                }
                else
                {
                    var addressInDB = _context.Addresses.Where(a => a.StreetAddress == donor.Address.StreetAddress).Where(a => a.City == donor.Address.City)
                        .Where(a => a.State == donor.Address.State).Where(a => a.ZipCode == donor.Address.ZipCode).FirstOrDefault();
                    donorinDB.AddressId = addressInDB.Id;
                }
                if (donorinDB.MedicalId == null)
                {
                    MedicalHistory newMedical = new MedicalHistory();
                    newMedical = donor.MedicalHistory;
                    _context.MedicalHistories.Add(newMedical);
                    _context.SaveChanges();
                    var medicalInDB = _context.MedicalHistories.Where(m => m.Age == donor.MedicalHistory.Age).Where(m => m.BloodType == donor.MedicalHistory.BloodType)
                        .Where(m => m.Ethnicity == donor.MedicalHistory.Ethnicity).Where(m => m.HasAllergies == donor.MedicalHistory.HasAllergies)
                        .Where(m => m.Height == donor.MedicalHistory.Height).Where(m => m.IsMale == donor.MedicalHistory.IsMale)
                        .Where(m => m.OnMedications == donor.MedicalHistory.OnMedications).Where(m => m.Weight == donor.MedicalHistory.Weight).FirstOrDefault();
                    donorinDB.MedicalId = medicalInDB.Id;
                }
                else
                {
                    var medicalInDB = _context.MedicalHistories.Where(m => m.Age == donor.MedicalHistory.Age).Where(m => m.BloodType == donor.MedicalHistory.BloodType)
                        .Where(m => m.Ethnicity == donor.MedicalHistory.Ethnicity).Where(m => m.HasAllergies == donor.MedicalHistory.HasAllergies)
                        .Where(m => m.Height == donor.MedicalHistory.Height).Where(m => m.IsMale == donor.MedicalHistory.IsMale)
                        .Where(m => m.OnMedications == donor.MedicalHistory.OnMedications).Where(m => m.Weight == donor.MedicalHistory.Weight).FirstOrDefault();
                    donorinDB.MedicalId = medicalInDB.Id;
                }
                _context.Donors.Update(donorinDB);
                _context.SaveChanges();
                return Ok(donorinDB);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id, [FromBody]Donor donor)
        {
            _context.Donors.Remove(donor);
            _context.SaveChanges();
            return Ok(donor);
        }
    }
}
