using NUnit.Framework;

namespace Sedol.UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        private Sedol _objSedol;

        public UnitTest()
        {
            _objSedol = new Sedol();
        }

        [TestCase("")]
        [TestCase("12")]
        [TestCase("123456789")]
        [TestCase(null)]
        public void InputLengthNotMatch(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(false, result.IsValidSedol);
            Assert.AreEqual(false, result.IsUserDefined);
            Assert.AreEqual(Common.InputLengthNotMatching, result.ValidationDetails);
        }

        [TestCase("1234567")]
        public void InputWithInvalidCheckDigit(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(false, result.IsValidSedol);
            Assert.AreEqual(false, result.IsUserDefined);
            Assert.AreEqual(Common.InputInvalidSedol, result.ValidationDetails);
        }

        [TestCase("0709954")]
        [TestCase("B0YBKJ7")]
        public void ValidNonUserDefinedSedol(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(true, result.IsValidSedol);
            Assert.AreEqual(false, result.IsUserDefined);
            Assert.AreEqual(null, result.ValidationDetails);
        }

        [TestCase("9123451")]
        [TestCase("9ABCDE8")]
        public void UserDefinedInputWithInvalidCheckDigit(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(false, result.IsValidSedol);
            Assert.AreEqual(true, result.IsUserDefined);
            Assert.AreEqual(Common.InputInvalidSedol, result.ValidationDetails);
        }

        [TestCase("9123_51")]
        [TestCase("VA.CDE8")]
        public void InputWithInvalidChar(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(false, result.IsValidSedol);
            Assert.AreEqual(false, result.IsUserDefined);
            Assert.AreEqual(Common.InputWithInvalidChar, result.ValidationDetails);
        }

        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void ValidUserDefinedSedol(string value)
        {
            var result = _objSedol.ValidateSedol(value);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ISedolValidationResult>(result);
            Assert.AreEqual(true, result.IsValidSedol);
            Assert.AreEqual(true, result.IsUserDefined);
            Assert.AreEqual(null, result.ValidationDetails);
        }
    }
}
