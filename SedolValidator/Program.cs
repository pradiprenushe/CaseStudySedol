using System;

namespace Sedol
{
    class Program
    {
        static void Main(string[] args)
        {
            string strContinue = "y";
            while (string.Equals(strContinue, "y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter Sedol Text for validate");
                Sedol objSedol = new Sedol();
                ISedolValidationResult SedolResult = objSedol.ValidateSedol(Console.ReadLine());
                Console.WriteLine((string.IsNullOrEmpty(SedolResult.InputString) ? "null" : SedolResult.InputString) + " | " + SedolResult.IsValidSedol + " | "+ SedolResult.IsUserDefined +" | "+ (String.IsNullOrEmpty(SedolResult.ValidationDetails)?"null":SedolResult.ValidationDetails) );
                Console.WriteLine("Do you want to continue y/n");
                strContinue = Console.ReadLine();
            }
        }
    }
}
