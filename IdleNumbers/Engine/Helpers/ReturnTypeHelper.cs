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
                    < 0 => new BigNumber(bgrNbr.Number, bgrNbr.Exposant + 10000, baseNum.TypeToString),
                    
                    _ => new BiggerNumber(bgrNbr.Number, bgrNbr.Exposant, baseNum.TypeToString)
                },
                
                BigNumber bNbr => bNbr.Exposant switch
                {
                    < 6 => new ClassicNumber((int)(bNbr.Number * Math.Pow(10, bNbr.Exposant)),  baseNum.TypeToString),
                    
                    >= 10000 => new BiggerNumber(bNbr.Number, bNbr.Exposant - 10000, baseNum.TypeToString),
                    
                    _ => new BigNumber(bNbr.Number, bNbr.Exposant, baseNum.TypeToString)
                },
                
                ClassicNumber cNbr => cNbr switch
                {
                    { Number: < 1000000 } => new ClassicNumber(cNbr.Number, baseNum.TypeToString),
                    
                    { Number: >= 1000000 } => new BigNumber(cNbr.Number, baseNum.TypeToString),
                },
                
                _ => throw new InvalidOperationException("Type not supported")
            };
        }

        #region ConvertToCorrectType

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
                return (new BigNumber(bigA.Number, bigA.Exposant + 10000, a.TypeToString), new BigNumber(classicB.Number, b.TypeToString));

            if (a is BiggerNumber && b is BigNumber bigB)
                return (a, new BiggerNumber(bigB.Number, (bigB).Exposant, b.TypeToString));

            return (a, new BigNumber(b.Number, b.TypeToString));
        }

        private static bool IsNumberTypeSuperior(BaseNumber a, BaseNumber b)
        {
            var ta = a.GetType();
            var tb = b.GetType();
            return ta == typeof(BigNumber) && tb == typeof(ClassicNumber)
                   || ta == typeof(BiggerNumber) && tb == typeof(ClassicNumber)
                   || ta == typeof(BiggerNumber) && tb == typeof(BigNumber);
        }

        #endregion ConvertToCorrectType
    }
}
