using Probability.Core.Models;

namespace Probability.Core.Contracts
{
    public interface IProbabilityCalculatorSupervisor
    {
        decimal CalculateProbability(CalculateProbabilityRequest request);
    }
}
