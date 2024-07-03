using IdleNumbers;
using IdleNumbers.Engine;
using IdleNumbers.Engine.Helpers;
using IdleNumbers.Numbers;
using IdleUpgrades;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
    public class GameEngine
    {
        //Qi
        private BaseNumber CurrentQi;
        private BaseNumber QiPerClick;
        private BaseNumber QiPerSecond;
        private BaseNumber QiBonusPerSecond;

        //Gold
        private BaseNumber CurrentGold;
        private BaseNumber GoldPerClick;
        private BaseNumber GoldPerSecond;
        private BaseNumber GoldBonusPerSecond;

        //Upgrades
        private List<BaseUpgrade> AvailableUpgrades;
        private List<BaseUpgrade> BoughtUpgrades;
        private List<BaseUpgrade> Upgrades;

        //Services
        private readonly UpgradeService _upgradeService;
        
        //GameState
        private readonly GameState _gameState;

        public GameEngine()
        {
            _upgradeService = new UpgradeService();
            _gameState = new GameState();
            Initialize();
        }

        public void ApplyUpgrade(BaseUpgrade upgrade)
        {
            if (upgrade is not NormalUpgrade normalUpgrade) 
                return;

            if (normalUpgrade.Effect is null)
                return;

            switch (normalUpgrade.UpgradeType)
            {
                case TypeUpgradeEnum.GoldPerClick:
                    GoldPerClick = OperationService.Add(GoldPerClick, normalUpgrade.Effect);
                    break;
                case TypeUpgradeEnum.GoldPerSecond:
                    GoldPerClick = OperationService.Add(GoldPerClick, normalUpgrade.Effect);
                    break;
                case TypeUpgradeEnum.QiPerClick:
                    QiPerClick = OperationService.Add(QiPerClick, normalUpgrade.Effect);
                    break;
                case TypeUpgradeEnum.QiPerSecond:
                    QiPerSecond = OperationService.Add(QiPerSecond, normalUpgrade.Effect);
                    break;
                case TypeUpgradeEnum.UnlockingContent:
                case TypeUpgradeEnum.None:
                default:
                    return;
            }
        }

        public void BuyUpdate(BaseUpgrade upgrade)
        {
            if (!AvailableUpgrades.Contains(upgrade))
                return;

            if (upgrade is NormalUpgrade normalUpgrade)
            {
                if (!ReturnTypeHelper.IsNumberSuperiorOrEqual(CurrentQi, normalUpgrade.Cost))
                    return;
                CurrentQi = OperationService.Subtract(CurrentQi, normalUpgrade.Cost);
            }

            _upgradeService.BuyUpgrade(Upgrades.IndexOf(upgrade));
            ApplyUpgrade(upgrade);
        }

        public void ClickQi()
        {
            CurrentQi = ClickBase(CurrentQi, QiPerClick);
        }

        public void UpdateSate()
        {
            _gameState.CurrentChi = CurrentQi;
            _gameState.CurrentGold = CurrentGold;
            _gameState.UpgradesBought = _upgradeService.GetBoughtUpgrades();
        }

        private void Initialize()
        {
            //Initialize Qi
            CurrentQi = new ClassicNumber(0);
            QiPerClick = new ClassicNumber(1);
            QiPerSecond = new ClassicNumber(0);
            QiBonusPerSecond = new ClassicNumber(0);

            //Initialize Gold
            CurrentGold = new ClassicNumber(0);
            GoldPerSecond = new ClassicNumber(0);
            GoldBonusPerSecond = new ClassicNumber(0);

            //Initialize Upgrades
            AvailableUpgrades = _upgradeService.LoadUpgrades();
            BoughtUpgrades = new List<BaseUpgrade>();
            Upgrades = _upgradeService.LoadUpgrades();
        }

        private BaseNumber ClickBase(BaseNumber a, BaseNumber b)
        {
            return OperationService.Add(a, OperationService.Multiply(a, b));
        }

        private BaseNumber CalculatePerSecondBase(BaseNumber perSecond, BaseNumber bonusPerSecond)
        {
            return OperationService.Add(perSecond, OperationService.Multiply(bonusPerSecond, new ClassicNumber(100)));
        }
    }
}

