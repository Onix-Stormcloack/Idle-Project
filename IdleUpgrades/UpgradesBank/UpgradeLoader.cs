using IdleNumbers.Numbers;
using IdleUpgrades.Upgrades;

namespace IdleUpgrades.UpgradesBank
{
    internal class UpgradeLoader //TODO : Finish this class
    {
        private Dictionary<int, string> _upgradesTitle = new();
        private Dictionary<int, string> _upgradesDescription = new();
        private Dictionary<int, BaseNumber> _upgradesCost = new();
        private Dictionary<int, bool> _upgradesBought = new();

        public List<NormalUpgrade> LoadNormalUpgrades()
        {
            List<NormalUpgrade> upgrades = new();

            for (int i = 0; i < _upgradesTitle.Count; i++)
            {
                var upgrade = new NormalUpgrade(_upgradesTitle[i], _upgradesDescription[i], _upgradesCost[i]);
                upgrade.IsBought = _upgradesBought[i];
                upgrades.Add(upgrade);
            }

            return upgrades;
        }

        public UpgradeLoader()
        {
#if DEBUG
            InitializeUpgradeTest();
#endif
        }

        private void InitializeUpgradeTest()
        {
            _upgradesTitle.Add(0, "Upgrade 1");
            _upgradesDescription.Add(0, "This is the first upgrade");
            _upgradesCost.Add(0, new ClassicNumber(10));
            _upgradesBought.Add(0, false);

            _upgradesTitle.Add(1, "Upgrade 2");
            _upgradesDescription.Add(1, "This is the second upgrade");
            _upgradesCost.Add(1, new ClassicNumber(20));
            _upgradesBought.Add(1, false);

            _upgradesTitle.Add(2, "Upgrade 3");
            _upgradesDescription.Add(2, "This is the third upgrade");
            _upgradesCost.Add(2, new ClassicNumber(30));
            _upgradesBought.Add(2, false);

            _upgradesTitle.Add(3, "Upgrade 4");
            _upgradesDescription.Add(3, "This is the fourth upgrade");
            _upgradesCost.Add(3, new ClassicNumber(40));
            _upgradesBought.Add(3, false);

            _upgradesTitle.Add(4, "Upgrade 5");
            _upgradesDescription.Add(4, "This is the fifth upgrade");
            _upgradesCost.Add(4, new ClassicNumber(50));
            _upgradesBought.Add(4, false);

            _upgradesTitle.Add(5, "Upgrade 6");
            _upgradesDescription.Add(5, "This is the sixth upgrade");
            _upgradesCost.Add(5, new ClassicNumber(60));
            _upgradesBought.Add(5, false);

            _upgradesTitle.Add(6, "Upgrade 7");
            _upgradesDescription.Add(6, "This is the seventh upgrade");
            _upgradesCost.Add(6, new ClassicNumber(70));
            _upgradesBought.Add(6, false);

            _upgradesTitle.Add(7, "Upgrade 8");
            _upgradesDescription.Add(7, "This is the eighth upgrade");
            _upgradesCost.Add(7, new ClassicNumber(80));
            _upgradesBought.Add(7, false);

            _upgradesTitle.Add(8, "Upgrade 9");
            _upgradesDescription.Add(8, "This is the ninth upgrade");
            _upgradesCost.Add(8, new ClassicNumber(90));
            _upgradesBought.Add(8, false);

            _upgradesTitle.Add(9, "Upgrade 10");
            _upgradesDescription.Add(9, "This is the tenth upgrade");
            _upgradesCost.Add(9, new ClassicNumber(100));
            _upgradesBought.Add(9, false);
        }
    }
}
