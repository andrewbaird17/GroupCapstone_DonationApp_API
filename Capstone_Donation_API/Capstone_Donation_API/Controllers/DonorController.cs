using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Capstone_Donation_API.Data;
using Capstone_Donation_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

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
                    AddAddressToDB(donor.Address);
                    var addressInDB = GetAddressFromDB(donor.Address);
                    donorinDB.AddressId = addressInDB.Id;
                }
                else
                {
                    var addressInDB = GetAddressFromDB(donor.Address);
                    if (addressInDB == null)
                    {
                        AddAddressToDB(donor.Address);
                        var changedAddressInDB = GetAddressFromDB(donor.Address);
                        donorinDB.AddressId = changedAddressInDB.Id;
                    }
                    else
                    {
                        donorinDB.AddressId = addressInDB.Id;
                    }
                }
                if (donorinDB.MedicalId == null)
                {
                    AddMedicalInfoToDB(donor.MedicalHistory);
                    var medicalInDB = GetMedicalInfoFromDB(donor.MedicalHistory);
                    donorinDB.MedicalId = medicalInDB.Id;
                    donorinDB.IsActive = true;
                }
                else
                {
                    var medicalInDB = GetMedicalInfoFromDB(donor.MedicalHistory);
                    if (medicalInDB == null)
                    {
                        AddMedicalInfoToDB(donor.MedicalHistory);
                        var changedMedicalInDB = GetMedicalInfoFromDB(donor.MedicalHistory);
                        donorinDB.MedicalId = changedMedicalInDB.Id;
                        donorinDB.IsActive = true;
                    }
                    else
                    {
                        donorinDB.MedicalId = medicalInDB.Id;
                    }
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

        public void AddAddressToDB(Address address)
        {
            Address newAddress = new Address();
            newAddress = address;
            _context.Addresses.Add(newAddress);
            _context.SaveChanges();
        }

        public void AddMedicalInfoToDB(MedicalHistory medicalHistory)
        {
            MedicalHistory newMedical = new MedicalHistory();
            newMedical = medicalHistory;
            _context.MedicalHistories.Add(newMedical);
            _context.SaveChanges();
        }

        public Address GetAddressFromDB(Address address)
        {
            var addressInDB = _context.Addresses.Where(a => a.StreetAddress == address.StreetAddress).Where(a => a.City == address.City)
                        .Where(a => a.State == address.State).Where(a => a.ZipCode == address.ZipCode).FirstOrDefault();
            return addressInDB;
        }

        public MedicalHistory GetMedicalInfoFromDB(MedicalHistory medicalHistory)
        {
            var medicalInDB = _context.MedicalHistories.Where(m => m.Age == medicalHistory.Age).Where(m => m.BloodType == medicalHistory.BloodType)
                        .Where(m => m.Ethnicity == medicalHistory.Ethnicity).Where(m => m.HasAllergies == medicalHistory.HasAllergies)
                        .Where(m => m.Height == medicalHistory.Height).Where(m => m.IsMale == medicalHistory.IsMale)
                        .Where(m => m.OnMedications == medicalHistory.OnMedications).Where(m => m.Weight == medicalHistory.Weight).FirstOrDefault();
            return medicalInDB;
        }

        //public async Task GetLatAndLongAsync(Address address)
        //{
        //    string fullAddress = address.StreetAddress + ", " + address.City + ", " + address.State + " " + address.ZipCode;
        //    string url = "https://maps.googleapis.com/maps/api/geocode/json?address="+fullAddress+"&key="+API_Key.Googlekey;
        //    using (HttpClient googleClient = new HttpClient())
        //    {
        //        HttpResponseMessage response = await googleClient.GetAsync(url);
        //        var data = await response.Content.ReadAsStringAsync();

        //    }
        //}
    }
}
