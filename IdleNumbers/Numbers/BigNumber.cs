namespace IdleNumbers.Numbers
{
    internal class BigNumber : ExposantNumber
    {

        public BigNumber(float nbrBase, int exposant) : base(nbrBase, exposant) { }

        public BigNumber(int number) : base(0, 0)
        {
            SetFullNumber(number);
        }

        public int GetFullNumber()
        {
            return (int)(Number * Math.Pow(10, _exposant));
        }

        public void SetFullNumber(int number)
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
