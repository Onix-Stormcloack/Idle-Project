using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Numbers
{
    public abstract class ExposantNumber : BaseNumber
    {
        protected int _exposant;

        public int Exposant
        {
            get => _exposant;
            set => _exposant = value;
        }

        protected ExposantNumber(float nbrBase, int exposant) : base(nbrBase)
        {
            _exposant = exposant;
            Precision = 3;
        }
    }
}
