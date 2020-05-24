using Microsoft.AspNetCore.Mvc;

namespace Probability.Web.ApiModels
{
    public class CalculateProbabilityApiRequest
    {
        [FromQuery(Name = "pA")]
        public decimal ProbabilityOfA { get; set; }
        [FromQuery(Name = "pB")]
        public decimal ProbabilityOfB { get; set; }
        [FromQuery(Name = "type")]
        public string CalculationType { get; set; }
    }


    public class CalculateProbabilityApiResponse
    {        
        public decimal Probability { get; set; }
    }
}
