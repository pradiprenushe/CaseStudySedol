namespace Sedol
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }
} 