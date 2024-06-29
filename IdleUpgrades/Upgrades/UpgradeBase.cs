using IdleNumbers.Numbers;

namespace IdleUpgrades.Upgrades
{
    public abstract class UpgradeBase
    {
        protected UpgradeBase(BaseNumber cost, string name, string description)
        {
            Cost = cost;
            Name = name;
            Description = description;
        }

        protected UpgradeBase()
        {
            Cost = new ClassicNumber(0);
            Name = "";
            Description = "";
        }

        public BaseNumber Cost;

        public string Name;

        public string Description;

    }
}
