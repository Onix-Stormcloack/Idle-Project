using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleNumbers.Numbers
{
    internal class BiggerNumber : BigNumber
    {
        public BiggerNumber(float nbrBase, int exposant) : base(nbrBase, exposant) { }

        public BiggerNumber(int number) : base(number)
        {
            var bNbr = new BigNumber(number);
            Number = bNbr.Number;
            _exposant = bNbr.Exposant - 10000;
        }

        public override string ToString()
        {
            return base.ToString().Replace('e', 'E');
        }
    }
}
