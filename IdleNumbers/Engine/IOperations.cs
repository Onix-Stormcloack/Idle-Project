using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers;

namespace IdleNumbers.Engine
{
    public interface IOperations
    {
        BaseNumber Add(BaseNumber a, BaseNumber b);
        BaseNumber Subtract(BaseNumber a, BaseNumber b);
        BaseNumber Multiply(BaseNumber a, BaseNumber b);
        BaseNumber Divide(BaseNumber a, BaseNumber b);
    }
}
