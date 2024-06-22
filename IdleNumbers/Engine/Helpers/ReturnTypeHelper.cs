using IdleNumbers.Numbers;

namespace IdleNumbers.Engine.Helpers
{
    public static class ReturnTypeHelper
    {
        public static BaseNumber GetCorrectReturnType(BaseNumber baseNum)
        {
            return baseNum switch
            {
                BiggerNumber bgrNbr => bgrNbr.Exposant switch
                {
                    < 0 => new BigNumber(bgrNbr.Number, bgrNbr.Exposant + 10000),
                    _ => new BiggerNumber(bgrNbr.Number, bgrNbr.Exposant)
                },
                BigNumber bNbr => bNbr.Exposant switch
                {
                    < 6 => new ClassicNumber((int)(bNbr.Number * Math.Pow(10, bNbr.Exposant))),
                    >= 10000 => new BiggerNumber(bNbr.Number, bNbr.Exposant - 10000),
                    _ => new BigNumber(bNbr.Number, bNbr.Exposant)
                },
                ClassicNumber cNbr => cNbr switch
                {
                    { Number: < 1000000 } => new ClassicNumber(cNbr.Number),
                    { Number: >= 1000000 } => new BigNumber(cNbr.Number),
                },
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        public static (BaseNumber, BaseNumber) ConvertToCorrectType(BaseNumber a, BaseNumber b)
        {
            if (a.GetType() == b.GetType())
                return (a, b);

            if (!IsNumberTypeSuperior(a, b))
            {
                var (correctB, correctA) = ConvertToCorrectType(b, a);
                return (correctA, correctB);
            }

            if (a is BiggerNumber bigA && b is ClassicNumber classicB)
                return (new BigNumber(bigA.Number,bigA.Exposant +10000), new BigNumber(classicB.Number));
            
            if(a is BiggerNumber && b is BigNumber bigB)
                return (a, new BiggerNumber(bigB.Number, (bigB).Exposant));
            
            return (a, new BigNumber(b.Number));
        }

        private static bool IsNumberTypeSuperior(BaseNumber a, BaseNumber b)
        {
            var ta = a.GetType();
            var tb = b.GetType();
            return ta == typeof(BigNumber) && tb == typeof(ClassicNumber)
                   || ta == typeof(BiggerNumber) && tb == typeof(ClassicNumber)
                   || ta == typeof(BiggerNumber) && tb == typeof(BigNumber);
        }
    }
}
