using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Capstone_Donation_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DonorController> _logger;

        public DonorController(ILogger<DonorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Donor> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Donor
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
