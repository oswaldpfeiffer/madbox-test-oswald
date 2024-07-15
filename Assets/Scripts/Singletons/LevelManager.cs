using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonBaseClass<LevelManager>, ILevelManager
{
    [SerializeField] private GameObject _enemiesManagerHolder;
    [SerializeField] private GameObject _heroInstance;

    [SerializeField] private SOHealth _heroHealth;

    private IEnemiesManager _enemiesManager;
    private IHeroController _heroController;

    private List<IEnemyController> _enemies;

    private void Start()
    {
        _enemiesManager = _enemiesManagerHolder.GetComponent(typeof(IEnemiesManager)) as IEnemiesManager;
        _heroController = _heroInstance.GetComponent(typeof(IHeroController)) as IHeroController;
        IHeroModel heroModel = new HeroModel();
        _heroController.Initialize(heroModel, _heroHealth);
        SpawnAndRegisterEnemies();
    }

    private void SpawnAndRegisterEnemies ()
    {
        _enemies = _enemiesManager.SpawnEnemies();
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
