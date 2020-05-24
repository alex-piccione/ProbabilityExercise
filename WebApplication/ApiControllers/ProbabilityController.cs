using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Probability.Core;
using Probability.Core.Exceptions;
using Probability.Core.Models;
using Probability.Web.ApiModels;

namespace Probability.Web.ApiControllers
{
    [ApiController, Route("api/probability")]
    public class ProbabilityController : ControllerBase
    {
        IProbabilityCalculator probabilityCalculator;

        public ProbabilityController(IProbabilityCalculator probabilityCalculator) {
            this.probabilityCalculator = probabilityCalculator;
        }

        [HttpGet("")]        
        public ActionResult Calculate([FromQuery]CalculateProbabilityApiRequest request)
        {
            var calculationRequest= new CalculateProbabilityRequest
            {
                ProbabilityOfA = request.ProbabilityOfA,
                ProbabilityOfB = request.ProbabilityOfB
            };

            try
            {
                var result = probabilityCalculator.CalculateProbability(calculationRequest);

                return Ok(new CalculateProbabilityApiResponse
                {
                    IsSuccess = true,
                    Probability = result
                });
            }
            catch (InvalidCalculateProbabilityRequest exc)
            {
                // log WARN exc 
                //return BadRequest(new { errors=exc.Errors });
                return Ok(new CalculateProbabilityApiResponse
                {
                    IsSuccess = false,
                    Errors = exc.Errors
                });
            }
            catch (Exception exc)
            {
                // log ERROR exc                   
                return new StatusCodeResult(500);
            }
        }

    }
}
