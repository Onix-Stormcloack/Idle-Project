using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Numbers
{
    internal class BigNumber : ExposantNumber
    {
        public BigNumber( float nbrBase, int exposant, EnumTypeToString type) : base(nbrBase, exposant, type) { }

        public BigNumber(float nbrBase, int exposant) : base(nbrBase, exposant) { }

        public BigNumber(float number) : base(0, 0)
        {
            SetFullNumber(number);
        }

        public BigNumber(float number, EnumTypeToString type) : base(0, 0, type)
        {
            SetFullNumber(number);
        }

        public float GetFullNumber()
        {
            return (float)(Number * Math.Pow(10, _exposant));
        }

        public void SetFullNumber(float number)
        {
            _exposant = 0;
            Number = number;
            while (Number >= 10)
            {
                Number /= 10;
                _exposant++;
            }
        }
    }
}
