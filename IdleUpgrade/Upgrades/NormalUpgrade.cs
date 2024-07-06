using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleNumbers.Numbers;

namespace IdleUpgrades.Upgrades
{
    public class NormalUpgrade : BaseUpgrade
    {
        public NormalUpgrade(string title, string description, BaseNumber cost, TypeUpgradeEnum type, BaseNumber? effect) : base(title, description, false)
        {
            Cost = cost;
            Effect = effect;

            UpgradeType = Effect is null 
                ? TypeUpgradeEnum.UnlockingContent 
                : type;
        }

        public BaseNumber Cost { get; set; }

        public TypeUpgradeEnum UpgradeType { get; set; }

        public BaseNumber? Effect { get; set; }
    }

    public enum TypeUpgradeEnum
    {
        None,
        QiPerClick,
        QiPerSecond,
        GoldPerClick,
        GoldPerSecond,
        UnlockingContent
    }
}
