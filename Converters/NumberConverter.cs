using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Clicker_Heroes_Calculator.Classes
{
    /// <summary>
    /// This class is used to convert large numbers into short readable number.
    /// </summary>
    public static class NumberConverter
    {
        /// <summary>
        /// This method converts a double number into a readable number.
        /// </summary>
        /// <param name="number">Number to be converted</param>
        /// <returns>A string of the converted number</returns>
        public static string Convert(double number)
        {
            if (number == double.MaxValue)
                return number.ToString();

            string[] SIUnits = { "", "", "K", "M", "B", "T", "q", "Q", "s", "S", "O", "N", "d", "U", "D", "!", "@", "#", "$", "%", "^", "&", "*" };
            string symbol = "";
            string scientificNotation = string.Format("{0:#.###e-0}", number);
            int digitCount = int.Parse(scientificNotation.Substring(scientificNotation.IndexOf("e") + 1)) + 1;

            if (digitCount > 65)
                return scientificNotation;
            else
                symbol = SIUnits[digitCount / 3];

            double numberScaled = digitCount < 6 ? number : Math.Floor(number / (Math.Pow(1000.0, (digitCount / 3) - 1)));

            string tempString;
            tempString = string.Format("{0:#,#}", numberScaled);
            return tempString + symbol;
        }
    }
}
