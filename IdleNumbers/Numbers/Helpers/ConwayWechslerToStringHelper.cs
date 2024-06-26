namespace IdleNumbers.Numbers.Helpers
{
    public static class ConwayWechslerToStringHelper
    {
        private static readonly string Suffixe = "ilion";

        private static readonly string[] Prefixes = new[]
        {
            "", "un", "duo", "tr", "quadr", "quint", "sext", "sept", "oct", "non"
        };

        private static readonly string[] TensPrefixes = new[]
        {
            "", "deci", "viginti", "triginta", "quadraginta", "quinquaginta", "sexaginta", "septuaginta", "octoginta",
            "nonaginta"
        };

        private static readonly string[] HundredsPrefixes = new[]
        {
            "", "centi", "ducenti", "trecenti", "quadringenti", "quingenti", "sexcenti", "septingenti", "octingenti",
            "nongenti"
        };

        private static readonly string[] ThousandsPrefixes = new[]
        {
            "", "milli", "miri", "micri", "nano", "pico", "femto", "atto", "zepto", "yocto"
        };

        private static readonly char[] LastCharToRemove = new[] { 'a', 'i'};

        public static string GetSuffix(int exponent)
        {
            int thousands = exponent / 3 - 1; // 1 for thousand, 2 for million, etc.

            switch (thousands)
            {
                case < 1:
                    return string.Empty;
                case > 9999:
                    return "infinity";
            }

            var suffix = CorrectPrefixEnd(SuperiorSuffixRecursive(thousands));
            
            suffix += Suffixe;

            return suffix;
        }

        private static string SuperiorSuffixRecursive(int number, int depth = 0)
        {
            var quotient = number / 10;
            var remainder = number % 10;
            var ret = string.Empty;
            if(quotient == 0)
                return GetCorrectPrefixesFromNumber(number, depth);
            return  SuperiorSuffixRecursive(quotient, depth + 1) + GetCorrectPrefixesFromNumber(remainder, depth);
        }

        private static string GetCorrectPrefixesFromNumber(int number, int depth)
        {
            return depth switch
            {
                0 => Prefixes[number],
                1 => TensPrefixes[number],
                2 => HundredsPrefixes[number],
                3 => ThousandsPrefixes[number],
                _ => string.Empty
            };
        }

        private static string CorrectPrefixEnd(string prefix)
        {
            if (LastCharToRemove.Contains(prefix.Last()))
                return prefix.Remove(prefix.Length - 1);
            return prefix;
        }
    }
}
