using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Probability.Core.Exceptions;
using Probability.Core.Models;

namespace Probability.Core.Calculators
{
    public class ProbabilityCalculator : IProbabilityCalculator
    {
        string[] validProbabilityTypes = { ProbabilityType.CombinedWith, ProbabilityType.Either };

        public decimal CalculateProbability(CalculateProbabilityRequest request)
        {
            ValidateRequest(request);

            return request.ProbabilityOfA + request.ProbabilityOfB;
        }

        private void ValidateRequest(CalculateProbabilityRequest request)
        {
            var errors = new List<string>(3);

            if (request.ProbabilityOfA < 0 || request.ProbabilityOfA > 1)
                errors.Add("Probability of A must be in the range 0-1");

            if (request.ProbabilityOfB < 0 || request.ProbabilityOfB > 1)
                errors.Add("Probability of B must be in the range 0-1");

            if (!validProbabilityTypes.Contains(request.ProbabilityType))
                errors.Add($@"Probability ""{request.ProbabilityType}"" is not valid");

            if (errors.Count > 0)
                throw new InvalidCalculateProbabilityRequest(errors.ToArray());
        }
    }
}
