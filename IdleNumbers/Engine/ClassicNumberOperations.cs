using IdleNumbers.Engine.Helpers;
using IdleNumbers.Numbers;
using IdleNumbers.Numbers.Helpers;

namespace IdleNumbers.Engine
{
    internal class ClassicNumberOperations : IOperations
    {
        public BaseNumber Add(BaseNumber a, BaseNumber b)
        {
            if (a is not ClassicNumber classicA || b is not ClassicNumber classicB)
                throw new InvalidOperationException("InvalidTypes for Add Operation");

            var result = classicA.Number + classicB.Number;
            
            if (classicA.Number > 0 && classicB.Number > 0 && result < 0)
                return new ExposantOperations().Add(new BigNumber(classicA.Number, a.TypeToString), new BigNumber(classicB.Number, a.TypeToString));

            return ReturnTypeHelper.GetCorrectReturnType(new ClassicNumber(result, a.TypeToString));
        }

        public BaseNumber Subtract(BaseNumber a, BaseNumber b)
        {
            if (a is not ClassicNumber classicA || b is not ClassicNumber classicB)
                throw new InvalidOperationException("InvalidTypes for Substract Operation");
            
            var result = classicA.Number - classicB.Number;

            if (result < 0)
                throw new InvalidOperationException("Result is negative");

            return new ClassicNumber(result, a.TypeToString);
        }

        public BaseNumber Multiply(BaseNumber a, BaseNumber b)
        {
            if (a is not ClassicNumber classicA || b is not ClassicNumber classicB)
                throw new InvalidOperationException("InvalidTypes for Multiply Operation");
            
            var result = classicA.Number * classicB.Number;

            if (classicA.Number > 0 && classicB.Number > 0 && result < 0)
                return new ExposantOperations().Multiply(new BigNumber(classicA.Number, a.TypeToString), new BigNumber(classicB.Number, a.TypeToString));

            return ReturnTypeHelper.GetCorrectReturnType(new ClassicNumber(result, a.TypeToString));
        }

        public BaseNumber Divide(BaseNumber a, BaseNumber b)
        {
            if (a is not ClassicNumber classicA || b is not ClassicNumber classicB)
                throw new InvalidOperationException("InvalidTypes for Divide Operation");
            
            if(classicB.Number == 0)
                throw new InvalidOperationException("Can't divide by 0");

            var result = classicA.Number / classicB.Number;

            if (result < 0)
                throw new InvalidOperationException("Result is negative");

            return new ClassicNumber(result, a.TypeToString);
        }
    }
}
