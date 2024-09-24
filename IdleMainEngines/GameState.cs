using IdleNumbers.Numbers;

namespace IdleMainEngine
{
    public class GameState
    {
        public GameState()
        {
            CurrentChi = new ClassicNumber(0);
            CurrentGold = new ClassicNumber(0);
            ChiPerSecond = new ClassicNumber(0,1);
            GoldPerSecond = new ClassicNumber(0,1);
            UpgradesBought = new List<int>();
        }

        public BaseNumber CurrentChi { get; set; }

        public BaseNumber CurrentGold { get; set; }

        public BaseNumber ChiPerSecond { get; set; }

        public BaseNumber GoldPerSecond { get; set; }

        public List<int> UpgradesBought { get; set; }

        // Add any other game state properties here
    }
}