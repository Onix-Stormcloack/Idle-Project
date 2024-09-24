using System.Timers;
using IdleNumbers;
using IdleNumbers.Numbers;
using IdleNumbers.Operations.Helpers;
using IdleUpgrades;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
    public class GameEngine
    {
        //Timer
        public static System.Timers.Timer MainTimer = new();
        
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
        public List<BaseUpgrade> AvailableUpgrades { get; private set; }
        public List<BaseUpgrade> BoughtUpgrades { get; private set; }
        public List<BaseUpgrade> Upgrades { get; private set; }

        //Services
        private readonly UpgradeService _upgradeService;
        
        //GameState
        public readonly GameState GameState;

        public GameEngine()
        {
            _upgradeService = new UpgradeService();
            GameState = new GameState();
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
            BoughtUpgrades.Add(upgrade);
            AvailableUpgrades.Remove(upgrade);
            ApplyUpgrade(upgrade);
            UpdateSate();
        }

        public void ClickMain()
        {
            CurrentQi = ClickBase(CurrentQi, QiPerClick);
            CurrentGold = ClickBase(CurrentGold, GoldPerClick);
            UpdateSate();
        }

        public void UpdateSate()
        {
            GameState.CurrentChi = CurrentQi;
            GameState.CurrentGold = CurrentGold;
            GameState.ChiPerSecond = QiPerSecond;
            GameState.GoldPerSecond = GoldPerSecond;
            GameState.UpgradesBought = _upgradeService.GetBoughtUpgrades();
        }

        private void Initialize()
        {
            //Initialize Qi
            CurrentQi = new ClassicNumber(0);
            QiPerClick = new ClassicNumber(1);
            QiPerSecond = new ClassicNumber(0,1);
            QiBonusPerSecond = new ClassicNumber(0, 1);

            //Initialize Gold
            CurrentGold = new ClassicNumber(0);
            GoldPerClick = new ClassicNumber(0);
            GoldPerSecond = new ClassicNumber(0, 1);
            GoldBonusPerSecond = new ClassicNumber(0, 1);

            //Initialize Upgrades
            AvailableUpgrades = _upgradeService.LoadUpgrades();
            BoughtUpgrades = new List<BaseUpgrade>();
            Upgrades = _upgradeService.LoadUpgrades();

            //Initialize Timer
            MainTimer.Interval = 1000;
            MainTimer.Elapsed += MainTimerTick;
            MainTimer.Start();
        }

        private BaseNumber ClickBase(BaseNumber a, BaseNumber b)
        {
            return OperationService.Add(a,b);
        }

        private BaseNumber SecondBase(BaseNumber current, BaseNumber persecond, BaseNumber bonus)
        {
            return OperationService.Add(current, CalculatePerSecondBase(persecond, bonus));
        }

        private BaseNumber CalculatePerSecondBase(BaseNumber perSecond, BaseNumber bonusPerSecond)
        {
            return OperationService.Add(perSecond, OperationService.Multiply(bonusPerSecond, new ClassicNumber(100)));
        }

        private void MainTimerTick(object? sender, ElapsedEventArgs e)
        {
            if(GoldPerSecond.Number == 0 && QiPerSecond.Number == 0)
                return;
            CurrentQi = SecondBase(CurrentQi, QiPerSecond, QiBonusPerSecond);
            CurrentGold = SecondBase(CurrentGold, GoldPerSecond, GoldBonusPerSecond);
            UpdateSate();
        }
    }
}

