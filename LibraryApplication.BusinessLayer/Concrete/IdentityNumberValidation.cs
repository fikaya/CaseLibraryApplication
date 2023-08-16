using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Concrete
{
    public static class IdentityNumberValidation
    {
        public static bool IdentityNumberControl(string IdentityNumber)
        {
            int algorithmStepCheck = 0, addingSingleDigits = 0, SumofDoubleDigits = 0, SumofAllDigits= 0, digit10 = 0, digit11 = 0;

            if (IdentityNumber.Length == 11) algorithmStepCheck = 1;

            foreach (char chr in IdentityNumber) { if (Char.IsNumber(chr)) algorithmStepCheck = 2; }

            if (IdentityNumber.Substring(0, 1) != "0") algorithmStepCheck = 3;

            int[] arrTC = System.Text.RegularExpressions.Regex.Replace(IdentityNumber, "[^0-9]", "").Select(x => (int)Char.GetNumericValue(x)).ToArray();

            for (int i = 0; i < IdentityNumber.Length; i++)
            {
                SumofAllDigits += Convert.ToInt32(arrTC[i]);
                if (((i + 1) % 2) == 0)
                {
                    if (i + 1 != 10) SumofDoubleDigits += Convert.ToInt32(arrTC[i]);
                    else digit10 = Convert.ToInt32(arrTC[i]);
                }
                else
                {
                    if (i + 1 != 11) addingSingleDigits += Convert.ToInt32(arrTC[i]);
                    else
                    {
                        digit11 = Convert.ToInt32(arrTC[i]);
                        SumofAllDigits = SumofAllDigits - digit11;
                    }
                }
            }

            int firstValue = (addingSingleDigits * 7) - SumofDoubleDigits;
            int firstValue_mod10 = firstValue % 10;
            if (digit10 == firstValue_mod10) algorithmStepCheck = 4;

            int secondValue_mod10 = SumofAllDigits % 10;
            if (digit11 == secondValue_mod10) algorithmStepCheck = 5;

            if (algorithmStepCheck == 5)
                return true;
            else
                return false;
        }
    }
}
