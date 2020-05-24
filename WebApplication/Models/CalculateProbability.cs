namespace Probability.Web.Models
{
    public class CalculateProbabilityRequest
    {
        public decimal ProbabilityOfA { get; set; }
        public decimal ProbabilityOfB { get; set; }
    }


    public class CalculateProbabilityResponse
    {        
        public decimal Probability { get; set; }
    }
}
