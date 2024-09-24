using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Input;
using IdleMainEngine;
using IdleUpgrades.Upgrades;

namespace MainTestingApp.VM
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<BaseUpgrade> Upgrades { get; set; }
        public ObservableCollection<BaseUpgrade> UpgradesBought { get; set; }
        public ICommand BuyUpgradeCommand { get; set; }
        public ICommand ShowUpgradeDetailsCommand { get; set; }

        public ICommand MainClickCommand { get; set; }

        public GameEngine GameEngine { get; set; }

        #region MainNumbers
        
        private string _currentQi;

        public string CurrentQi
        {
            get => _currentQi;
            set
            {
                _currentQi = value;
                OnPropertyChanged();
            }
        }

        private string _currentGold;

        public string CurrentGold
        {
            get => _currentGold;
            set
            {
                _currentGold = value;
                OnPropertyChanged();
            }
        }

        private string _currentQiperSecond;

        public string CurrentQiperSecond
        {
            get => _currentQiperSecond;
            set
            {
                _currentQiperSecond = value;
                OnPropertyChanged();
            }
        }

        private string _currentGoldperSecond;

        public string CurrentGoldperSecond
        {
            get => _currentGoldperSecond;
            set
            {
                _currentGoldperSecond = value;
                OnPropertyChanged();
            }
        }

        #endregion MainNumbers

        #region Popup

        private string _popupTitle;

        public string PopupTitle
        {
            get => _popupTitle;
            set
            {
                _popupTitle = value;
                OnPropertyChanged();
            }
        }

        private string _popupPrice;

        public string PopupPrice
        {
            get => _popupPrice;
            set
            {
                _popupPrice = value;
                OnPropertyChanged();
            }
        }

        private string _popupDescription;

        public string PopupDescription
        {
            get => _popupDescription;
            set
            {
                _popupDescription = value;
                OnPropertyChanged();
            }
        }

        private BaseUpgrade _selectedUpgrade;

        public BaseUpgrade SelectedUpgrade
        {
            get => _selectedUpgrade;
            set
            {
                _selectedUpgrade = value;
                ShowUpgradeDetails(_selectedUpgrade);
                OnPropertyChanged();
            }
        }

        private void ShowUpgradeDetails(BaseUpgrade upgrade)
        {
            PopupTitle = upgrade.Title;
            PopupDescription = upgrade.Description;
            if (upgrade is not NormalUpgrade normalUpgrade)
                return;
            PopupPrice = normalUpgrade.Cost.ToString();
        }

        #endregion Popup

        public MainWindowVM()
        {
            _currentQi = "0";
            _currentGold = "0";
            _currentQiperSecond = "0.0";
            _currentGoldperSecond = "0.0";
            GameEngine = new GameEngine();
            //Timer
            GameEngine.MainTimer.Elapsed += MainTimerScreenTick;


            UpgradesBought = new ObservableCollection<BaseUpgrade>();
            Upgrades = new ObservableCollection<BaseUpgrade>();
            ActualizeUpgrades();

            _popupTitle = "";
            _popupPrice = "";
            _popupDescription = "";
            
            BuyUpgradeCommand = new RelayCommand(BuyUpgrade);
            ShowUpgradeDetailsCommand = new RelayCommand<BaseUpgrade>(ShowUpgradeDetails);
            MainClickCommand = new RelayCommand(MainClick);
        }

        public void MainClick(object parameter)
        {
            GameEngine.ClickMain();
            ActualizeCurrentNumbers();
        }

        private void MainTimerScreenTick(object? sender, ElapsedEventArgs e)
        {
            ActualizeCurrentNumbers();
        }

        private void BuyUpgrade(object parameter)
        {
            var upgrade = (BaseUpgrade)parameter;
            GameEngine.BuyUpdate(upgrade);
            ActualizeCurrentNumbers();
            ActualizeUpgrades();
        }

        private void ActualizeCurrentNumbers()
         {
            CurrentQi = GameEngine.GameState.CurrentChi.ToString();
            CurrentGold = GameEngine.GameState.CurrentGold.ToString();
            CurrentQiperSecond = GameEngine.GameState.ChiPerSecond.ToString();
            CurrentGoldperSecond = GameEngine.GameState.GoldPerSecond.ToString();
        }

        private void ActualizeUpgrades()
        {
            Upgrades.Clear();
            UpgradesBought.Clear();
            foreach (var upgrade in GameEngine.AvailableUpgrades)
                if (upgrade is NormalUpgrade normalUpgrade)
                    Upgrades.Add(normalUpgrade);

            foreach (var boughtUpgrade in GameEngine.BoughtUpgrades)
                if(boughtUpgrade is NormalUpgrade normalUpgrade)
                    UpgradesBought.Add(normalUpgrade);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

