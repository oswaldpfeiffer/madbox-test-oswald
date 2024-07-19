using System;
using System.Collections.Generic;

public interface IEnemiesManager
{
    List<IEnemyController> SpawnEnemies(IHeroController heroController, SOLevelData levelData, IWeaponsManager weaponsManager);
    void Initialize(SOLevelData levelData, Action onInitializationComplete);
}
