using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Numbers
{
    public abstract class BaseNumber
    {
        protected BaseNumber(float nbrBase)
        {
            Number = nbrBase;
        }

        protected BaseNumber(float number, int precision)
        {
            Number = number;
            Precision = precision;
        }

        protected BaseNumber(float number, EnumTypeToString typeToString)
        {
            Number = number;
            TypeToString = typeToString;
        }

        protected BaseNumber(float number, int precision, EnumTypeToString typeToString)
        {
            Number = number;
            Precision = precision;
            TypeToString = typeToString;
        }

        public float Number { get; set; }

        public int Precision;

        public EnumTypeToString TypeToString = EnumTypeToString.Standard;
        
        public override string ToString()
        {
            return NumberToStringHelper.NumberToString(this, TypeToString);
        }
    }
}
