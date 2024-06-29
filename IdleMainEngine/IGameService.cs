using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
    public interface IGameService //TODO : Finish this class
    {
        void ApplyUpgrade(BaseUpgrade upgrade);
        void PerformCalculation();
        void Click();
        GameState GetGameState();
    }
}
