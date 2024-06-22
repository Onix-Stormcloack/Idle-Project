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
                    { Number: >= 1000000 } => GetCorrectReturnType(new BiggerNumber(cNbr.Number))
                },
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        public static (BaseNumber, BaseNumber) ConvertToCorrectType(BaseNumber a, BaseNumber b)
        {
            if (a.GetType() == b.GetType())
                return (a, b);

            if (!IsNumberTypeSuperior(a, b))
                return (ConvertToCorrectType(b, a).Item2, b);

            if (a is BigNumber)
                return (a, new BigNumber(((ClassicNumber)b).Number));

            if (a is BiggerNumber && b is ClassicNumber classicB)
                return (a, new BiggerNumber(classicB.Number));

            return (a, new BiggerNumber(((BigNumber)b).Number, ((BigNumber)b).Exposant));
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
