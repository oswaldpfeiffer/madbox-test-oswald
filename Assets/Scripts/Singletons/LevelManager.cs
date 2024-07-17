using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonBaseClass<LevelManager>, ILevelManager
{
    [SerializeField] private List<SOLevelData> _levelsData;

    [SerializeField] private GameObject _heroInstance;

    [SerializeField] private SOHeroData _heroData;
    [SerializeField] private SOEnemyData _enemyData;

    private IEnemiesManager _enemiesManager;
    private IWeaponsManager _weaponsManager;
    private IHeroController _heroController;
    private ISceneManager _sceneManager;
    private IAudioManager _audioManager;

    private SOLevelData _levelData;
    private List<IEnemyController> _enemies;

    private void Start()
    {
        _enemiesManager = GetComponent(typeof(IEnemiesManager)) as IEnemiesManager;
        _weaponsManager = GetComponent(typeof(IWeaponsManager)) as IWeaponsManager;
        _sceneManager = ServiceLocator.Instance.GetService<ISceneManager>();
        _audioManager = ServiceLocator.Instance.GetService<IAudioManager>();
        _sceneManager.LoadHUDScreen(OnHUDLoaded);
    }

    private void OnHUDLoaded ()
    {
        InitLevelData();
        InitWeapons();
    }

    private void InitLevelData()
    {
        int levelIndex = ServiceLocator.Instance.GetService<IPersistentDataManager>().GetCurrentLevel();
        _levelData = _levelsData[levelIndex % _levelsData.Count];
    }

    private void InitWeapons()
    {
        _weaponsManager.Initialize(OnWeaponsInitialized);
    }
    private void OnWeaponsInitialized()
    {
        _enemiesManager.Initialize(_levelData, OnEnemiesInitialized);
    }

    private void OnEnemiesInitialized()
    {
        InitPlayer();
        SpawnEnemies();
    }

    private void InitPlayer()
    {
        _heroController = _heroInstance.GetComponent(typeof(IHeroController)) as IHeroController;
        IHeroModel heroModel = new HeroModel();
        _heroController.Initialize(heroModel, _heroData, this as ILevelManager, _weaponsManager, _audioManager);
        _heroController.EquipWeapon(_weaponsManager.PickWeaponRandomly());
        ServiceLocator.Instance.GetService<IInputsManager>().SetControllable(_heroController);
    }

    private void SpawnEnemies()
    {
        _enemies = _enemiesManager.SpawnEnemies(_heroController, _levelData);
    }

    public IEnemyController GetClosestEnemy(Vector3 position)
    {
        float closest = Mathf.Infinity;
        IEnemyController closestEnemy = null;
        foreach(IEnemyController enemy in _enemies)
        {
            if (enemy.IsAlive())
            {
                float dist = (position - enemy.GetPositionTransform().transform.position).magnitude;
                if (dist < closest)
                {
                    closest = dist;
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }
}
