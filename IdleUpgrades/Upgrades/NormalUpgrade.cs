using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers;

namespace IdleUpgrades.Upgrades
{
    internal class NormalUpgrade : BaseUpgrade
    {
        public NormalUpgrade(string title, string description, BaseNumber cost) : base(title, description, false)
        {
            Cost = cost;
        }

        public BaseNumber Cost { get; set; }
    }
}
