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

        public override string ToString()
        {
            return base.ToString().Replace('e', 'E');
        }
    }
}
