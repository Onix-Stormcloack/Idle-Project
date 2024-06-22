using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleNumbers.Numbers
{
    public abstract class BaseNumber
    {
        protected BaseNumber(object nbrBase)
        {
            NbrBase = nbrBase;
        }

        protected object NbrBase { get; set; }



        public int Precision = 4;
        
        public override string ToString()
        {
            if (NbrBase is float f)
                return f.ToString($"F{Precision}");
            return NbrBase.ToString() ?? throw new InvalidOperationException($"The _number of type {NbrBase.GetType()} can't be return as a string");
        }
    }
}
