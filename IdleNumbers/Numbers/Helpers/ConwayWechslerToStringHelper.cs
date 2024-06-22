using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleNumbers.Numbers.Helpers
{
    public static class ConwayWechslerToStringHelper
    {
        private static readonly string illion = "illion";
        
        private static readonly string[] Prefixes = new[]
        {
            "", "un", "duo", "tre", "quattuor", "quin", "sex", "septen", "octo", "novem"
        };

        private static readonly string[] TensPrefixes = new[]
        {
            "", "deci", "viginti", "triginta", "quadraginta", "quinquaginta", "sexaginta", "septuaginta", "octoginta", "nonaginta"
        };

        private static readonly string[] HundredsPrefixes = new[]
        {
            "", "centi", "ducenti", "trecenti", "quadringenti", "quingenti", "sexcenti", "septingenti", "octingenti", "nongenti"
        };

        public static string GetSuffix(int exponent)
        {
            if (exponent is < 3 or > 999)
                return string.Empty;

            int thousands = exponent / 3 - 1; // 1 for thousand, 2 for million, etc.

            int ones = thousands % 10;
            int tens = (thousands / 10) % 10;
            int hundreds = (thousands / 100) % 10;

            string suffix = string.Empty;

            if (hundreds > 0)
                suffix += HundredsPrefixes[hundreds];

            if (tens > 0)
                suffix += TensPrefixes[tens];

            if (ones > 0 || (hundreds == 0 && tens == 0))
                suffix += Prefixes[ones];

            suffix += illion;

            return suffix;
        }
    }
}
