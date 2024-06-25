using System.Globalization;

namespace IdleNumbers.Numbers.Helpers
{
    public static class NumberToStringHelper
    {
        public static string NumberToString(BaseNumber number, EnumTypeToString typeToString)
        {
            return typeToString switch
            {
                EnumTypeToString.Scientific => ScientificNumberToString(number),
                EnumTypeToString.Standard => StandardNumberToString(number),
                EnumTypeToString.Letters => LettersNumberToString(number),
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        #region Scientific

        private static string ScientificNumberToString(BaseNumber number)
        {
            return number switch
            {
                ClassicNumber cNbr => ClassicNumberToScientificString(cNbr),
                ExposantNumber exp => ExposantNumberToScientificString(exp),
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        private static string ClassicNumberToScientificString(ClassicNumber number)
        {
            if (number.Number < 10000)
                return NumberToStringWithPrecision(number);
            var cnbrExp = 0;
            var cnbrToShow = number.Number;
            while (cnbrToShow >= 10)
            {
                cnbrToShow /= 10;
                cnbrExp++;
            }
            var strNbr = cnbrToShow.ToString($"F{number.Precision}");
            return $"{strNbr}e{cnbrExp}";
        }

        private static string ExposantNumberToScientificString(ExposantNumber exp)
        {
            var expString = exp is BiggerNumber ? "E" : "e";
            return NumberToStringWithPrecision(exp) + expString + exp.Exposant;
        }

        #endregion Scientific

        #region Standard

        private static string StandardNumberToString(BaseNumber number)
        {

            return number switch
            {
                ClassicNumber cNbr => ClassicNumberToStandardString(cNbr),
                ExposantNumber exp => ExposantNumberToStandardString(exp),
                _ => throw new InvalidOperationException("Type not supported")
            };

        }

        private static string ClassicNumberToStandardString(ClassicNumber number)
        {
            var cnbr = number.Number;
            var exposant = 0;
            while (cnbr >= 10)
            {
                cnbr /= 10;
                exposant++;
            }
            var strExp = exposant == 0 ? string.Empty : ConwayWechslerToStringHelper.GetSuffix(exposant);
            
            if(strExp.Contains("infinity"))
                return ClassicNumberToScientificString(number);

            return NumberToStringWithPrecision(number) + " " + strExp;
        }

        private static string ExposantNumberToStandardString(ExposantNumber number)
        {
            var exposant = number is BiggerNumber ? number.Exposant + 10000 : number.Exposant;
            var strExp = ConwayWechslerToStringHelper.GetSuffix(exposant);

            if(strExp.Contains("infinity"))
                return ExposantNumberToScientificString(number);

            return NumberToStringWithPrecision(number) + " " + strExp;
        }

        #endregion Standard

        #region Letters

        private static string LettersNumberToString(BaseNumber number)
        {
            return number switch
            {
                ClassicNumber cNbr => ClassicNumberToLettersString(cNbr),
                ExposantNumber exp => ExposantNumberToToLettersString(exp),
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        private static string ClassicNumberToLettersString(ClassicNumber number)
        {
            var cnbr = number.Number;
            var exposant = 0;
            while (cnbr >= 10)
            {
                cnbr /= 10;
                exposant++;
            }
            var strExp = exposant == 0 ? string.Empty : LettersToStringHelper.GetSuffix(exposant);
            return NumberToStringWithPrecision(number) + strExp;
        }

        private static string ExposantNumberToToLettersString(ExposantNumber number)
        {
            var exposant = number is BiggerNumber ? number.Exposant + 10000 : number.Exposant;
            return NumberToStringWithPrecision(number) + LettersToStringHelper.GetSuffix(exposant);
        }

        #endregion Letters

        public static string NumberToStringWithPrecision(BaseNumber nbr)
        {
            return nbr.Number.ToString($"F{nbr.Precision}");
        }
    }

    public enum EnumTypeToString
    {
        Scientific,
        Standard,
        Letters
    }
}
