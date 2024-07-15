using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : BaseService<IGameStateManager>, IGameStateManager
{
    private EGameState _gameState;

    public void ChangeGameState (EGameState newGameState)
    {
        if (_gameState != newGameState)
        {
            _gameState = newGameState;
            EventBus.TriggerGameStateChanged(_gameState);
        }
    }

    public EGameState GetCurrentGameState()
    {
        return _gameState;
    }
}
