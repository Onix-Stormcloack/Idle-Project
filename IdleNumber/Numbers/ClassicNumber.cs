using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Numbers
{
    public class ClassicNumber : BaseNumber
    {
        public ClassicNumber(float nbrBase) : base(nbrBase) { }

        public ClassicNumber(float number, int precision) : base(number, precision) { }

        public ClassicNumber(float number, EnumTypeToString typeToString) : base(number, typeToString) { }
    }
}
