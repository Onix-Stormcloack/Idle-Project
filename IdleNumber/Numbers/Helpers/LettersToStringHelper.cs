namespace IdleNumbers.Numbers.Helpers
{
    public static class LettersToStringHelper
    {
        private static readonly char[] BaseLetters = new[]
        {
            ' ', 'K', 'M', 'B', 'T'
        };

        private static readonly char[] LowerAlphabet = new[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };

        private static readonly char[] UpperAlphabet = new[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public static string GetSuffix(int exponent)
        {
            if (exponent is < 3)
                return string.Empty;

            int thousands = exponent / 3 - 1; // 1 for thousand, 2 for million, etc.

            if (thousands < BaseLetters.Length)
                return BaseLetters[thousands].ToString();

            var result = SuperiorLettersRecursive(thousands - (BaseLetters.Length - 1));
            if (result.Length == 1)
                result = 'a' + result;
            return result;
        }

        private static string SuperiorLettersRecursive(int number)
        {
            var quotient = number / 52;
            var remainder = number % 52;
            var ret = string.Empty;
            if (quotient == 0)
                return GetLetterFromNumber(number - 1);
            return SuperiorLettersRecursive(quotient) + GetLetterFromNumber(remainder - 1);
        }

        private static string GetLetterFromNumber(int nbr)
        {
            return nbr switch
            {
                < 0 => LowerAlphabet[0].ToString(),
                < 26 => LowerAlphabet[nbr].ToString(),
                < 52 => UpperAlphabet[nbr - 26].ToString(),
                _ => UpperAlphabet[25].ToString()
            };
        }
    }
}
