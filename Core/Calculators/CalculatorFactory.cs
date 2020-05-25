using Probability.Core.Contracts;
using Probability.Core.Models;
using System;

namespace Probability.Core.Calculators
{
    public class CalculatorFactory : ICalculatorFactory
    {
        public IProbabilityCalculator GetCalculator(string calculationType)
        => calculationType switch
        {
            CalculationType.CombinedWith => new CombinedWithProbabilityCalculator(),
            CalculationType.Either => new EitherProbabilityCalculator(),
            _ => throw new ArgumentException(message: $"Invalid calculation type: {calculationType}")
        };     
    }
}