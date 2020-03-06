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
            var donor = _context.Donors.Find(id);
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
            if (ModelState.IsValid)
            {
                _context.Donors.Update(donor);
                _context.SaveChanges();
                return Ok(donor);
            }
            return BadRequest();
            

        }

        [HttpDelete]
        public IActionResult Delete(int id, [FromBody]Donor donor)
        {
            _context.Donors.Remove(donor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
