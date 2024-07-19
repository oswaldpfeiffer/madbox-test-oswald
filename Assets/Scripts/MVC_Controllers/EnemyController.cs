using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{
    private IHeroController _hero;
    private IEnemyView _view;
    private IEnemyModel _model;
    private IAudioManager _audioManager;

    void Update ()
    {
        if (_model.IsAlive)
        {
            _view.LookAtHero(_hero);
            _view.UpdateHealthBar(_model.Health / _model.MaxHealth);

            float dist = DistanceToPosition(_hero.GetPositionTransform().position);
            if (dist <= _model.EnemyData.AttackRange)
            {
                AttackLogic();
                if (dist >= _model.EnemyData.MinDistanceToPlayer)
                {
                    MoveLogic();
                }
            }
        }
    }


    private void AttackLogic ()
    {
        if (Time.time < (_model.LastAttackTime + _model.EnemyData.AttackCooldown)) return;
        _view.Attack(_model.EnemyData.Damages);
        _model.LastAttackTime = Time.time;
    }

    private void MoveLogic ()
    {
        Vector3 diff = _hero.GetPositionTransform().position - GetPositionTransform().position;
        diff = diff.normalized * _model.EnemyData.MoveSpeed * Time.deltaTime;
        _view.AddMoveVector(diff);
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
        EventBus.TriggerOnEnemyKilled(_model.EnemyData.ScorePerKill);
        _audioManager.PlayAudioClip(EAudioClip.BeeDeath);
        StartCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay ()
    {
        WaitForSeconds wfs = new WaitForSeconds(3);
        yield return wfs;
        if (UnityEngine.Random.Range(0f, 1f) <= _model.EnemyData.WeaponDropRate)
        {
            _view.DropItem();
        }
        Destroy(this.gameObject);
    }

    public bool IsAlive ()
    {
        return _model.IsAlive;
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(IHeroController hero, IEnemyModel model, SOEnemyData enemyData, IAudioManager audioManager, IWeaponsManager weaponManager)
    {
        _audioManager = audioManager;
        _model = model;
        _view = GetComponent(typeof(IEnemyView)) as IEnemyView;
        _view.Initialize();
        _hero = hero;
        _model.EnemyData = enemyData;
        InitLife(enemyData.HealthSO);
        _model.EnemyState = EEnemyState.setTarget;
        _view.InitializeDrop(weaponManager);
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
