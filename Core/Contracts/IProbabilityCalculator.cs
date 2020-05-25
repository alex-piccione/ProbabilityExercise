using Probability.Core.Models;

namespace Probability.Core
{
    public interface IProbabilityCalculator
    {
        decimal Calculate(CalculateProbabilityInput input);
    }
}