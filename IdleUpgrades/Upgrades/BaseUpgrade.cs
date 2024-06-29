using IdleNumbers.Numbers;

namespace IdleUpgrades.Upgrades
{
    public abstract class BaseUpgrade
    {
        protected BaseUpgrade(string name, string description, bool isBought)
        {
            IsBought = isBought;
            Name = name;
            Description = description;
        }

        protected BaseUpgrade()
        {
            IsBought = false;
            Name = "";
            Description = "";
        }

        public bool IsBought;

        public string Name;

        public string Description;

    }
}
