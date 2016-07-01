using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetSPA;
using Microsoft.Extensions.Logging;

namespace DotnetSPAAPI.Controllers
{
    [Route("api/[controller]")]
    public class CalcController : Controller
    {
        ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        // GET api/calc/?balance=5&rate=0.02&years=10
        [HttpGet]
        public IActionResult Get(double balance, double rate, int years)
        {
            try
            {
                _logger.LogTrace("I am trace");
                _logger.LogDebug("I am debug");
                _logger.LogWarning("I am warning");
                var result = InterestCalculator.GetFinalBalance(balance, rate, years);
                _logger.LogInformation("Input: {Balance}, {Rate}, {Years} | Output: {Result}", balance, rate, years, result);
                return Ok(result);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae);
            }
        }
    }
}
