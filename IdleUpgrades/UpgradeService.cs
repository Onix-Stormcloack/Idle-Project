using IdleUpgrades.Upgrades;
using IdleUpgrades.UpgradesBank;

namespace IdleUpgrades
{
    public class UpgradeService
    {
        public UpgradeService()
        {
            var loader = new UpgradeLoader();
            _upgrades = loader.LoadNormalUpgrades();
        }

        private readonly List<BaseUpgrade> _upgrades;

        public List<BaseUpgrade> LoadUpgrades()
        {
            return _upgrades;
        }

        public BaseUpgrade LoadUpgrade(int key)
        {
            return _upgrades[key];
        }

        public void ResetUpgrades()
        {
            foreach (var upgrade in _upgrades)
            {
                upgrade.IsBought = false;
            }
        }

        public void ResetUpgrade(int key)
        {
            _upgrades[key].IsBought = false;
        }

        public void BuyUpgrade(int key)
        {
            _upgrades[key].IsBought = true;
        }

        public List<int> GetBoughtUpgrades()
        {
            var boughtUpgrades = new List<int>();
            foreach (var upgrade in _upgrades)
            {
                if (!upgrade.IsBought) 
                    continue;
                boughtUpgrades.Add(_upgrades.IndexOf(upgrade));
            }
            return boughtUpgrades;
        }
    }
}
