namespace Probability.Core.Models
{
    public class CalculateProbabilityInput
    {
        public decimal ProbabilityOfA { get; set; }
        public decimal ProbabilityOfB { get; set; }        

        public static CalculateProbabilityInput FromCalculateProbabilityRequest(CalculateProbabilityRequest request) {
            return new CalculateProbabilityInput { 
                ProbabilityOfA = request.ProbabilityOfA,
                ProbabilityOfB = request.ProbabilityOfB,
            };
        }
    }
}
