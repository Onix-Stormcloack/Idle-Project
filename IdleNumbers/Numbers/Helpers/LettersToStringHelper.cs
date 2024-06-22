using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if(thousands < BaseLetters.Length)
                return BaseLetters[thousands].ToString();
            return SuperiorLetters(thousands - 4);
        }

        private static string SuperiorLetters(int thousands)
        {
            var bigLettersChange = thousands / 50;
            var smallLettersChange = thousands % 50;
            
            if(bigLettersChange > 50 || smallLettersChange > 50)
                throw new InvalidOperationException("Number too big");

            var strBigLetter = bigLettersChange < 25 ? LowerAlphabet[bigLettersChange].ToString() : UpperAlphabet[bigLettersChange - 25].ToString();
            var strSmallLetter = smallLettersChange < 25 ? LowerAlphabet[smallLettersChange].ToString() : UpperAlphabet[smallLettersChange - 25].ToString();

            return strBigLetter + strSmallLetter;
        }
    }
}
