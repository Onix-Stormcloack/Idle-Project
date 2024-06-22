using IdleNumbers.Engine.Helpers;
using IdleNumbers.Numbers;

namespace IdleNumbers.Engine
{
    public static class OperationsFactory
    {
        public static IOperations CreateOperations(Type type)
        {
            if (type == typeof(ClassicNumber))
                return new ClassicNumberOperations();

            if (type == typeof(BigNumber) || type == typeof(BiggerNumber))
                return new ExposantOperations();

            throw new NotSupportedException($"Operations for type {type} are not supported.");
        }

        private static IOperations GetOperations(BaseNumber a)
        {
            return CreateOperations(a.GetType());
        }

        public static BaseNumber Add(BaseNumber a, BaseNumber b)
        {
            var (convertedA, convertedB) = ReturnTypeHelper.ConvertToCorrectType(a, b);
            return GetOperations(convertedA).Add((dynamic)convertedA, (dynamic)convertedB);
        }

        public static BaseNumber Subtract(BaseNumber a, BaseNumber b)
        {
            var (convertedA, convertedB) = ReturnTypeHelper.ConvertToCorrectType(a, b);
            return GetOperations(convertedA).Subtract((dynamic)convertedA, (dynamic)convertedB);
        }

        public static BaseNumber Multiply(BaseNumber a, BaseNumber b)
        {
            var (convertedA, convertedB) = ReturnTypeHelper.ConvertToCorrectType(a, b);
            return GetOperations(convertedA).Multiply((dynamic)convertedA, (dynamic)convertedB);
        }

        public static BaseNumber Divide(BaseNumber a, BaseNumber b)
        {
            var (convertedA, convertedB) = ReturnTypeHelper.ConvertToCorrectType(a, b);
            return GetOperations(convertedA).Divide((dynamic)convertedA, (dynamic)convertedB);
        }
    }
}
