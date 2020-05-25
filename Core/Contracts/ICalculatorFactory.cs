namespace Probability.Core.Contracts
{
    public interface ICalculatorFactory
    {
        IProbabilityCalculator GetCalculator(string calculationType);
    }
}
