using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Numbers
{
    internal class BiggerNumber : BigNumber
    {
        public BiggerNumber(float nbrBase, int exposant) : base(nbrBase, exposant) { }

        public BiggerNumber(float nbrBase, int exposant, EnumTypeToString type) : base(nbrBase, exposant, type) { }
    }
}
