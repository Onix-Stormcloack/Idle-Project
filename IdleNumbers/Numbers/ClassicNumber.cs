using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleNumbers.Numbers
{
    public class ClassicNumber : BaseNumber
    {
        public ClassicNumber(int nbrBase) : base(nbrBase) { }

        public int Number
        {
            get => (int)NbrBase;
            set => NbrBase = value;
        }
    }
}
