using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_Donation_API.Data;
using Capstone_Donation_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_Donation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private ApplicationContext _context;

        public AddressController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Address> Get()
        {
            var AddressArray = _context.Addresses.ToArray();
            return AddressArray;
        }

        [HttpGet("{id}")]
        public Address Get(int id)
        {
            var address = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
            return address;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return Ok(address);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Addresses.Update(address);
                _context.SaveChanges();
                return Ok(address);
            }
            return BadRequest();


        }

        [HttpDelete]
        public IActionResult Delete(int id, [FromBody]Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
            return Ok(address);
        }
    }
}