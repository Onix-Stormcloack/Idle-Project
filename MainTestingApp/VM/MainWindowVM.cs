using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IdleMainEngine;
using IdleUpgrades.Upgrades;

namespace MainTestingApp.VM
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<NormalUpgrade> Upgrades { get; set; }
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

        private NormalUpgrade _selectedUpgrade;

        public NormalUpgrade SelectedUpgrade
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
            GameEngine = new GameEngine();
            
            Upgrades = new ObservableCollection<NormalUpgrade>();
            foreach (var upgrade in GameEngine.AvailableUpgrades)
                if (upgrade is NormalUpgrade normalUpgrade)
                    Upgrades.Add(normalUpgrade);

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
            CurrentQi = GameEngine.GameState.CurrentChi.ToString();
            CurrentGold = GameEngine.GameState.CurrentGold.ToString();
        }

        private void BuyUpgrade(object parameter)
        {
            var upgrade = (BaseUpgrade)parameter;
            GameEngine.BuyUpdate(upgrade);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

