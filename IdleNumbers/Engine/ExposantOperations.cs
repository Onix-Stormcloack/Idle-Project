using IdleNumbers.Engine.Helpers;
using IdleNumbers.Numbers;

namespace IdleNumbers.Engine
{
    internal class ExposantOperations : IOperations
    {
        public BaseNumber Add(BaseNumber a, BaseNumber b)
        {
            if (a is not ExposantNumber expA || b is not ExposantNumber expB)
                throw new InvalidOperationException("InvalidTypes for Add Operation");
            var exposant = expA.Exposant;
            float number;
            if (exposant == expB.Exposant)
            {
                number = expA.Number + expB.Number;
                while (number >= 10)
                {
                    number /= 10;
                    exposant++;
                }
            }
            else
            {
                bool isASuperieur = expA.Exposant > expB.Exposant;
                var exposantDifference = isASuperieur ? expA.Exposant - expB.Exposant : expB.Exposant - expA.Exposant;
                number = isASuperieur ? expB.Number : expA.Number;
                while (exposantDifference > 0)
                {
                    number /= 10;
                    exposantDifference--;
                }
                number += isASuperieur ? expA.Number : expB.Number;
                while (number >= 10)
                {
                    number /= 10;
                    exposant++;
                }
            }
            return ReturnTypeHelper.GetCorrectReturnType(GetCorrectExposantNumber(number, exposant, expA));
        }

        public BaseNumber Subtract(BaseNumber a, BaseNumber b)
        {
            if (a is not ExposantNumber expA || b is not ExposantNumber expB)
                throw new InvalidOperationException("InvalidTypes for Substract Operation");
            var exposantDifference = expA.Exposant - expB.Exposant;
            float number;
            var exposant = expA.Exposant;
            if (exposantDifference < 0)
                throw new InvalidOperationException("Can't substract by a bigger number");
            if (exposantDifference > 0)
            {
                while (exposantDifference > 0)
                {
                    expB.Number /= 10;
                    exposantDifference--;
                }
            }
            number = expA.Number - expB.Number;
            if (number < 0)
                throw new InvalidOperationException("Result is negative");
            while (number < 1)
            {
                number *= 10;
                exposant--;
            }
            return ReturnTypeHelper.GetCorrectReturnType(GetCorrectExposantNumber(number, exposant, expA));
        }

        public BaseNumber Multiply(BaseNumber a, BaseNumber b)
        {
            if (a is not ExposantNumber expA || b is not ExposantNumber expB)
                throw new InvalidOperationException("InvalidTypes for Multiply Operation");
            var exposant = expA.Exposant + expB.Exposant;
            var number = expA.Number * expB.Number;
            while (number >= 10)
            {
                number /= 10;
                exposant++;
            }

            return ReturnTypeHelper.GetCorrectReturnType(GetCorrectExposantNumber(number, exposant, expA));
        }

        public BaseNumber Divide(BaseNumber a, BaseNumber b)
        {
            if (a is not ExposantNumber expA || b is not ExposantNumber expB)
                throw new InvalidOperationException("InvalidTypes for Divide Operation");
            var exposant = expA.Exposant - expB.Exposant;
            var number = expA.Number / expB.Number;
            if (number < 0)
                throw new InvalidOperationException("Result is negative");
            while (number < 1)
            {
                number *= 10;
                exposant--;
            }
            if (exposant <= 0)
                return new ClassicNumber(number);
            return ReturnTypeHelper.GetCorrectReturnType(GetCorrectExposantNumber(number, exposant, expA));
        }

        private ExposantNumber GetCorrectExposantNumber(float number, int exposant, ExposantNumber entryNumber)
        {
            return entryNumber switch
            {
                BiggerNumber => new BiggerNumber(number, exposant),
                BigNumber => new BigNumber(number, exposant),
                _ => throw new InvalidOperationException("Error in type")
            };
        }
    }
}
