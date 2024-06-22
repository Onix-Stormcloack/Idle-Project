using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return $"{base.ToString()}e{_exposant}";
        }

        protected ExposantNumber(float nbrBase, int exposant) : base(nbrBase)
        {
            _exposant = exposant;
            Precision = 3;
        }
    }
}
