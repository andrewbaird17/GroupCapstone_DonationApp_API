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
    public class MedicalHistoryController : Controller
    {
        private ApplicationContext _context;

        public MedicalHistoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MedicalHistory> Get()
        {
            var medicalArray = _context.MedicalHistories.ToArray();
            return medicalArray;
        }

        [HttpGet("{id}")]
        public MedicalHistory Get(int id)
        {
            var medHistory = _context.MedicalHistories.Where(a => a.Id == id).FirstOrDefault();
            return medHistory;
        }

        [HttpPost]
        public IActionResult Post([FromBody]MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Add(medicalHistory);
            _context.SaveChanges();
            return Ok(medicalHistory);
        }

        [HttpPut]
        public IActionResult Put([FromBody]MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                _context.MedicalHistories.Update(medicalHistory);
                _context.SaveChanges();
                return Ok(medicalHistory);
            }
            return BadRequest();


        }

        [HttpDelete]
        public IActionResult Delete(int id, [FromBody]MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Remove(medicalHistory);
            _context.SaveChanges();
            return Ok(medicalHistory);
        }
    }
    
}