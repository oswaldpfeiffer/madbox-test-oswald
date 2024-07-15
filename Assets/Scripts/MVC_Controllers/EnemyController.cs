using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{
    private IHeroController _hero;
    private IEnemyView _view;
    private IEnemyModel _model;

    void Update ()
    {
        _view.LookAtHero(_hero);
    }
    public Transform GetPositionTransform()
    {
        return _view.MoveableTransform;
    }

    public void Die()
    {
        _model.IsAlive = false;
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(IHeroController hero)
    {
        _view = GetComponent(typeof(IEnemyView)) as IEnemyView;
        _view.Initialize();
        _hero = hero;
    }

    public void InitLife(SOHealth health)
    {
        _model.Health = health.MaxLife;
    }

    public void TakeDamage(float damages)
    {
        if (!_model.IsAlive) return;
        _model.Health -= damages;
        if (_model.Health <= 0)
        {
            Die();
        }
    }
}
