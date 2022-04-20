namespace Sedol
{
    static class Common
    {
        #region sedol Error messages-
        public const string InputLengthNotMatching = "Input string was not 7 -characters long";
        public const string InputWithInvalidChar = "SEDOL contains invalid characters";
        public const string InputInvalidSedol = "Checksum digit does not agree with the rest of the input";
        public const string SedolValidateUsermessage = "Error occured while, validating. Please try again.";
        #endregion sedol Error messages

        #region sedol constants
        // If module need to be configurable then below values must be out of assembly and declared as read not const
        // i.e some external source(DB/config file)
        public const string WeightageList = "1,3,1,7,3,9,1";
        public const int DigitCountForCheck = 6;
        public const string UserDefinedDigit = "9";
        public const string SedolRegex = "^[a-zA-Z0-9]{6}[0-9]{1}$";
        public const int ModuloConstant = 32; //64 for upper case 32 for both upper case and lower case
        #endregion sedol constants
    }
}