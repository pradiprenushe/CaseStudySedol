using System. Text . RegularExpressions;

namespace Sedol
{
    class SedolValidator : ISedolValidator
    {
        private readonly ISedolCheckDigitCalculator _objcalculator;
        public SedolValidator(ISedolCheckDigitCalculator objCalculator)
        {
            _objcalculator = objCalculator;
        }
        public ISedolValidationResult ValidateSedol(string input)
        {
            SedolValidationResult objResult =new SedolValidationResult();
            objResult.InputString = input;
            objResult.IsValidSedol = true;

            if (!string.IsNullOrEmpty(input) && input.StartsWith(Common.UserDefinedDigit))
            {
                objResult.IsUserDefined = true;
            }

            if (string.IsNullOrEmpty(input) || input.Length != Common.DigitCountForCheck + 1)
            {
                objResult.IsValidSedol = false;
                objResult.ValidationDetails = Common.InputLengthNotMatching;
            }

            Regex regexInput = new Regex(Common.SedolRegex);
            
            if(objResult.IsValidSedol && !regexInput.IsMatch(input))
            {
                objResult.IsValidSedol = false;
                objResult.IsUserDefined = false;
                objResult.ValidationDetails = Common.InputWithInvalidChar;
            }

            if(objResult.IsValidSedol && !string.IsNullOrEmpty(input))
            {
                int i = _objcalculator.CalculateSedolCheckDigit(input);
                if (input.Substring(input.Length - 1, 1) == i.ToString())
                    objResult.ValidationDetails = null;
                else
                {
                    objResult.IsValidSedol = false;
                    objResult.ValidationDetails = Common.InputInvalidSedol;
                }
            }

            return objResult;
        }
    }
}

