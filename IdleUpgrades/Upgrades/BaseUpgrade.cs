using IdleNumbers.Numbers;

namespace IdleUpgrades.Upgrades
{
    public abstract class BaseUpgrade
    {
        protected BaseUpgrade(string title, string description, bool isBought)
        {
            IsBought = isBought;
            Title = title;
            Description = description;
        }

        protected BaseUpgrade()
        {
            IsBought = false;
            Title = "";
            Description = "";
        }

        public bool IsBought;

        public string Title;

        public string Description;

    }
}
