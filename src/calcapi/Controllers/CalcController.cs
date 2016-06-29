using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetSPA;

namespace DotnetSPAAPI.Controllers
{
    [Route("api/[controller]")]
    public class CalcController : Controller
    {
        // GET api/calc/?balance=5&rate=0.02&years=10
        [HttpGet]
        public IActionResult Get(double balance, double rate, int years)
        {
            try
            {
                return Ok(InterestCalculator.GetFinalBalance(balance, rate, years));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae);
            }
        }
    }
}
