using Probability.Core.Models;

namespace Probability.Core.Contracts
{
    public interface ICalculationStorer
    {
        void StoreCalculation(ExecutedCalculation calculation);
    }
}
