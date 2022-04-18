namespace Sedol
{
    public interface ISedolCheckDigitCalculator
    {
        short CalculateSedolCheckDigit(string input);
    }
}
