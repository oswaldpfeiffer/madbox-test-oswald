using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseService<IGameManager>, IGameManager
{
    public void StartGame()
    {
        throw new System.NotImplementedException();
    }

    protected override void Awake()
    {
        // Call the base Awake method first to register the service :
        base.Awake();
        // Additional initialization specific to service :
    }
}
