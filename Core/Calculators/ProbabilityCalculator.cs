using Probability.Core.Models;

namespace Probability.Core.Calculators
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        public decimal CalculateProbability(CalculateProbabilityRequest request)
        {
            return request.ProbabilityOfA + request.ProbabilityOfB;
        }
    }
}
