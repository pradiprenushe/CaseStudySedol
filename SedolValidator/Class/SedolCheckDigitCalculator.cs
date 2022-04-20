using System.Collections.Generic;
using System. Linq;
using System. Text;

namespace Sedol
{
    class SedolCheckDigitCalculator: ISedolCheckDigitCalculator
    {
        public short CalculateSedolCheckDigit(string input)
        {
            MassageSedolString(ref input);
            List<short> objSedolDigitList = input.Substring(0, input.Length - 2).Split(',').Select(short.Parse).ToList<short>();
            List<short> weighateChar = Common.WeightageList.Split(',').Select(short.Parse).ToList<short>();
            short amount = 0;
            for(int i=0; i < objSedolDigitList.Count; i++)
            {
                amount += (short)(objSedolDigitList[i] * weighateChar[i]);
            }
            return (short)((10 - (amount % 10)) % 10);
        }

        private void MassageSedolString(ref string strRawInput)
        {
            StringBuilder strBuildMassagedInput = new StringBuilder();
            int tempIntSedolDigit = 0;
            foreach (var SedolChar in strRawInput)
            {
                if ((SedolChar >= 'a' && SedolChar <= 'z') || (SedolChar >= 'A' && SedolChar <= 'Z'))
                    tempIntSedolDigit = (((int)SedolChar % Common.ModuloConstant) + 9);
                else
                    tempIntSedolDigit = int.Parse(SedolChar.ToString());

                strBuildMassagedInput.Append("," + tempIntSedolDigit.ToString());
            }
            strRawInput = strBuildMassagedInput.Remove(0, 1).ToString();
        }
    }
}

