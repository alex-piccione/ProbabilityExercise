using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Probability.Web.Models;

namespace Probability.Web.Controllers
{
    [ApiController, Route("api/probability")]
    public class ProbabilityController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult Calculate(
            [FromQuery(Name = "pA")] decimal probabilityOfA, 
            [FromQuery(Name = "pB")] decimal probabilityOfB)
        {

            var request = new CalculateProbabilityRequest { 
                ProbabilityOfA = probabilityOfA,
                ProbabilityOfB = probabilityOfB
            };

            var response = new CalculateProbabilityResponse {
                Probability = 0m
            };

            return Ok(response);
        }

    }
}
