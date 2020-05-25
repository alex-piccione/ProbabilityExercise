using Probability.Core.Contracts;
using Probability.Core.Models;

namespace Probability.Core.Calculators
{
    /// <summary>
    /// Apply the formula pA + ((1-pA)*pB)
    /// </summary>
    public class EitherProbabilityCalculator : IProbabilityCalculator
    {
        public decimal Calculate(CalculateProbabilityInput input)
        => input.ProbabilityOfA + (input.ProbabilityOfB - (input.ProbabilityOfA * input.ProbabilityOfB));

    }
}
