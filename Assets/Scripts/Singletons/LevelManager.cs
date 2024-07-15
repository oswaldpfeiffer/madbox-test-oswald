using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonBaseClass<LevelManager>, ILevelManager
{
    [SerializeField] private List<SOLevelData> _levelsData;

    [SerializeField] private GameObject _enemiesManagerHolder;
    [SerializeField] private GameObject _heroInstance;

    [SerializeField] private SOHealth _heroHealth;
    [SerializeField] private SOEnemyData _enemyData;

    private IEnemiesManager _enemiesManager;
    private IHeroController _heroController;

    private SOLevelData _levelData;
    private List<IEnemyController> _enemies;

    private void Start()
    {
        LoadLevelData();
    }

    private void LoadLevelData()
    {
        int levelIndex = ServiceLocator.Instance.GetService<IPersistentDataManager>().GetCurrentLevel();
        _levelData = _levelsData[levelIndex % _levelsData.Count];

        _enemiesManager = _enemiesManagerHolder.GetComponent(typeof(IEnemiesManager)) as IEnemiesManager;
        _enemiesManager.Initialize(_levelData, OnLevelInitialized);
    }

    private void OnLevelInitialized()
    {
        InitPlayer();
        // InitEnemies();
    }

    private void InitPlayer()
    {
        _heroController = _heroInstance.GetComponent(typeof(IHeroController)) as IHeroController;
        IHeroModel heroModel = new HeroModel();
        _heroController.Initialize(heroModel, _heroHealth);
        ServiceLocator.Instance.GetService<IInputsManager>().SetControllable(_heroController);
    }

    private void InitEnemies()
    {
        _enemies = _enemiesManager.SpawnEnemies(_heroController, _levelData);
    }

    public IEnemyController GetCloserEnemy (Vector3 position)
    {

        return null;
    }

    public IHeroController GetHero ()
    {
        return _heroController;
    }
}
