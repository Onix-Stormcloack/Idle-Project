using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public float Number { get; set; }

        public int Precision;
        
        public override string ToString()
        {
            return Number.ToString($"F{Precision}");
        }
    }
}
