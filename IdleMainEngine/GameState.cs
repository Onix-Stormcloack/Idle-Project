using IdleNumbers;
using IdleNumbers.Numbers;
using IdleUpgrades;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
    public class GameState
    {
        //TODO: Add properties to represent the game state
        public BaseNumber CurrentNumber { get; set; }
        public IList<BaseUpgrade> AvailableUpgrades { get; set; }
        public BaseUpgrade SelectedUpgrade { get; set; }

        // Add any other game state properties here
    }
}