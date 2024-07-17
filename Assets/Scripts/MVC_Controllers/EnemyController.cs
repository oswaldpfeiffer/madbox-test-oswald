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
        if (_model.IsAlive)
        {
            _view.LookAtHero(_hero);
            _view.UpdateHealthBar(_model.Health / _model.MaxHealth);
        }
    }
    public Transform GetPositionTransform()
    {
        return _view.MoveableTransform;
    }

    public void Die()
    {
        _model.IsAlive = false;
        _view.PlayDieAnimation();
        _view.UpdateHealthBar(0f);
        Destroy(this.gameObject, 3f);
    }

    public bool IsAlive ()
    {
        return _model.IsAlive;
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(IHeroController hero, IEnemyModel model, SOHealth health)
    {
        _model = model;
        _view = GetComponent(typeof(IEnemyView)) as IEnemyView;
        _view.Initialize();
        _hero = hero;
        InitLife(health);
    }

    public void InitLife(SOHealth health)
    {
        _model.Health = health.MaxLife;
        _model.MaxHealth = health.MaxLife;
        _model.IsAlive = true;
    }

    public void TakeDamage(float damages)
    {
        if (!_model.IsAlive) return;
        _model.Health -= damages;
        if (_model.Health <= 0)
        {
            Die();
        } else
        {
            _view.PlayHitAnimation();
        }
    }
}
