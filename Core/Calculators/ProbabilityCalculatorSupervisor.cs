using System;
using System.Linq;
using System.Collections.Generic;

using Probability.Core.Exceptions;
using Probability.Core.Models;
using Probability.Core.Contracts;

namespace Probability.Core.Calculators
{
    public class ProbabilityCalculatorSupervisor : IProbabilityCalculatorSupervisor
    {
        ICalculatorFactory calculatorFactory;

        public ProbabilityCalculatorSupervisor(ICalculatorFactory calculatorFactory) {
            this.calculatorFactory = calculatorFactory;
        }

        string[] validProbabilityTypes = { CalculationType.CombinedWith, CalculationType.Either };

        public decimal CalculateProbability(CalculateProbabilityRequest request)
        {
            ValidateRequest(request);

            var input = CalculateProbabilityInput.FromCalculateProbabilityRequest(request);
            var calculatedProbability = calculatorFactory.GetCalculator(request.CalculationType).Calculate(input);

            return calculatedProbability;
        }

        private void ValidateRequest(CalculateProbabilityRequest request)
        {
            var errors = new List<string>(3);

            if (request.ProbabilityOfA < 0 || request.ProbabilityOfA > 1)
                errors.Add("Probability of A must be in the range 0-1");

            if (request.ProbabilityOfB < 0 || request.ProbabilityOfB > 1)
                errors.Add("Probability of B must be in the range 0-1");

            if (!validProbabilityTypes.Contains(request.CalculationType))
                errors.Add($@"Calculation type ""{request.CalculationType}"" is not valid");

            if (errors.Count > 0)
                throw new InvalidCalculateProbabilityRequest(errors.ToArray());
        }
    }
}
