using System;

namespace Sedol
{
    class Sedol
    {
        private readonly ISedolValidator _objValidator;
        public Sedol()
        {
            _objValidator = new SedolValidator(new SedolCheckDigitCalculator());
        }
        public ISedolValidationResult ValidateSedol(string input)
        {
            try
            {
                return _objValidator.ValidateSedol(input);
            }
            catch (Exception ex) /// log technical error with ex
            {
                //expose user friendly message
                throw new Exception(Common.SedolValidateUsermessage); //custom exception or exact exception can be thrown.
            }
        }
    }

}

