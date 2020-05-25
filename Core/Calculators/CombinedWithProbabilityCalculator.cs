using Probability.Core.Contracts;
using Probability.Core.Models;

namespace Probability.Core.Calculators
{
    public class CombinedWithProbabilityCalculator : IProbabilityCalculator
    {
        public decimal Calculate(CalculateProbabilityInput input)
        => input.ProbabilityOfA * input.ProbabilityOfB;
    }
}
