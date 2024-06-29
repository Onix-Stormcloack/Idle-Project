using IdleNumbers;
using IdleNumbers.Engine;
using IdleNumbers.Numbers;
using IdleUpgrades;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
    public class GameEngine //TODO : Finish this class
    {
        private readonly UpgradeService _upgradeService;

        public BaseNumber CurrentNumber { get; private set; }
        public IList<BaseUpgrade> AvailableUpgrades { get; private set; }

        public GameEngine()
        {
            _upgradeService = new UpgradeService();
            CurrentNumber = new ClassicNumber(0);
            //AvailableUpgrades = _upgradeService.GetAllUpgrades();
        }

        public void ApplyUpgrade(BaseUpgrade upgrade)
        {
            //_upgradeService.ApplyUpgrade(CurrentNumber, upgrade);
        }

        public void PerformCalculation()
        {
            //CurrentNumber = _calculationService.CalculateNewValue(CurrentNumber);
        }

        public void Click()
        {
            // Logic for handling click
            CurrentNumber.Number += 1;
        }
    }
}

