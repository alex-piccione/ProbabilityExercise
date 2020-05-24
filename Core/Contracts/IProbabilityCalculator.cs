using Probability.Core.Models;

namespace Probability.Core
{
    public interface IProbabilityCalculator
    {
        decimal CalculateProbability(CalculateProbabilityRequest request);
    }
}