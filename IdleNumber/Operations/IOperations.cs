using IdleNumbers.Numbers;

namespace IdleNumbers.Operations
{
    public interface IOperations
    {
        BaseNumber Add(BaseNumber a, BaseNumber b);
        BaseNumber Subtract(BaseNumber a, BaseNumber b);
        BaseNumber Multiply(BaseNumber a, BaseNumber b);
        BaseNumber Divide(BaseNumber a, BaseNumber b);
    }
}
