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

        private static readonly string[] ThousandsPrefixes = new[]
        {
            "", "milli", "miri", "micri", "nano", "pico", "femto", "atto", "zepto", "yocto", "xono"
        };

        public static string GetSuffix(int exponent)
        {
            int thousands = exponent / 3 - 1; // 1 for thousand, 2 for million, etc.

            if (thousands is < 1 or > 9999)
                return string.Empty;

            int ones = thousands % 10;
            int tens = (thousands / 10) % 10;
            int hundreds = (thousands / 100) % 10;
            thousands = (thousands / 1000) % 10;

            string suffix = string.Empty;

            if (thousands > 0)
                suffix += ThousandsPrefixes[thousands];

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
