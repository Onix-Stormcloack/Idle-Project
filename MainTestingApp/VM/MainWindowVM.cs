using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MainTestingApp.VM
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Upgrade> Upgrades { get; set; }
        public ICommand BuyUpgradeCommand { get; set; }
        public ICommand ShowUpgradeDetailsCommand { get; set; }

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

        public MainWindowVM()
        {
            Upgrades = new ObservableCollection<Upgrade>
            {
                new Upgrade { Title = "Upgrade 1", Price = "100", Description = "Description of Upgrade 1" },
                new Upgrade { Title = "Upgrade 2", Price = "200", Description = "Description of Upgrade 2" },
                new Upgrade { Title = "Upgrade 3", Price = "300", Description = "Description of Upgrade 3" }
            };
            _popupTitle = "";
            _popupPrice = "";
            _popupDescription = "";
            BuyUpgradeCommand = new RelayCommand(BuyUpgrade);
            ShowUpgradeDetailsCommand = new RelayCommand<Upgrade>(ShowUpgradeDetails);
        }

        private void BuyUpgrade(object parameter)
        {
            // Logic to handle the upgrade purchase
        }

        private void ShowUpgradeDetails(Upgrade upgrade)
        {
            PopupTitle = upgrade.Title;
            PopupPrice = $"Price: {upgrade.Price}";
            PopupDescription = upgrade.Description;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Upgrade
    {
        public Upgrade(string title, string price, string description)
        {
            Title = title;
            Price = price;
            Description = description;
        }

        public Upgrade()
        {
            Title = "";
            Price = "";
            Description = "";
        }

        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}

