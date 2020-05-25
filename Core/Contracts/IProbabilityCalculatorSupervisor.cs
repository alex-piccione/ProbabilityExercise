using Probability.Core.Models;

namespace Probability.Core.Contracts
{
    /// <summary>
    /// Component for managing the probability calculation requests.
    /// </summary>
    public interface IProbabilityCalculatorSupervisor
    {
        /// <summary>
        /// Calculate the probability.
        /// It also store the calculation data for future analysis.
        /// </summary>
        /// <remarks>
        /// A validation of the input is executed and if some value are not valid an InvalidCalculateProbabilityRequest is thrown        /// </summary>
        /// </remarks>
        decimal CalculateProbability(CalculateProbabilityRequest request);
    }
}
