using System;
using System.Runtime.CompilerServices;

namespace Probability.Core.Models
{
    public class ExecutedCalculation
    {
        public DateTime When { get; set; }
        public CalculateProbabilityInput Input { get; set; }
        public string CalculationType { get; set; }
        public decimal Result { get; set; }
    }
}
