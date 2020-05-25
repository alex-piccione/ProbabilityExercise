using Probability.Core.Models;

namespace Probability.Core.Contracts
{
    public interface IProbabilityCalculator
    {
        decimal Calculate(CalculateProbabilityInput input);
    }
}