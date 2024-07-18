using System;
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
            bool isCloseToPlayer = DistanceToPosition(_hero.GetPositionTransform().position) < _model.EnemyData.MoveDistance;
            if (isCloseToPlayer) {
                ActiveLogic();
            } else
            {
                PassiveLogic();
            }
            _view.UpdateHealthBar(_model.Health / _model.MaxHealth);
        }
    }

    private void ActiveLogic ()
    {
        if (_model.EnemyState == EEnemyState.setTarget)
        {
            _model.SetMoveTarget(GetPositionTransform().position, _hero.GetPositionTransform().position);
            _view.StartReachTarget(GetPositionTransform().position + _model.GetMoveTarget(), _model.GetReachTargetDuration(), TargetReached);
            _model.EnemyState = EEnemyState.move;
        }
    }

    private void TargetReached()
    {
        if (DistanceToPosition(_hero.GetPositionTransform().position) < _model.EnemyData.AttackDistance)
        {
            _view.Attack(_hero);
            _hero.TakeDamage(_model.EnemyData.AttackForce);
        }
        StartCoroutine(ResumeStateDelay());
    }

    private IEnumerator ResumeStateDelay ()
    {
        WaitForSeconds wfs = new WaitForSeconds(_model.EnemyData.AttackFrequency);
        yield return wfs;
        if (_model.IsAlive)
        {
            _model.SetMoveTarget(GetPositionTransform().position, _hero.GetPositionTransform().position);
            _model.EnemyState = EEnemyState.setTarget;
        }
    }

    private void PassiveLogic ()
    {
        _view.LookAtHero(_hero);
    }

    private float DistanceToPosition (Vector3 position)
    {
        return (position - GetPositionTransform().position).magnitude;
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

    public void Initialize(IHeroController hero, IEnemyModel model, SOEnemyData enemyData)
    {
        _model = model;
        _view = GetComponent(typeof(IEnemyView)) as IEnemyView;
        _view.Initialize();
        _hero = hero;
        _model.EnemyData = enemyData;
        InitLife(enemyData.HealthSO);
        _model.EnemyState = EEnemyState.setTarget;
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
