using Probability.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
