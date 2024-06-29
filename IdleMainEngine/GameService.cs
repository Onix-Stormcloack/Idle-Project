using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleUpgrades.Upgrades;

namespace IdleMainEngine
{
public class GameService : IGameService //TODO : Finish this class
{
    private readonly GameEngine _gameEngine;
    private readonly GameState _gameState;

    public GameService()
    {
        _gameEngine = new GameEngine();
        _gameState = new GameState
        {
            CurrentNumber = _gameEngine.CurrentNumber,
            AvailableUpgrades = _gameEngine.AvailableUpgrades
        };
    }

    public void ApplyUpgrade(BaseUpgrade upgrade)
    {
        _gameEngine.ApplyUpgrade(upgrade);
        UpdateGameState();
    }

    public void PerformCalculation()
    {
        _gameEngine.PerformCalculation();
        UpdateGameState();
    }

    public void Click()
    {
        _gameEngine.Click();
        UpdateGameState();
    }

    public GameState GetGameState()
    {
        return _gameState;
    }

    private void UpdateGameState()
    {
        _gameState.CurrentNumber = _gameEngine.CurrentNumber;
        _gameState.AvailableUpgrades = _gameEngine.AvailableUpgrades;
    }
}
}
