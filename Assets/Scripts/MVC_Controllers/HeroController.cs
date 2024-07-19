using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour, IHeroController
{
    private IHeroModel _model;
    private IHeroView _view;

    private ILevelManager _levelManager;
    private IWeaponsManager _weaponsManager;
    private IEnemyController _closestEnemy;
    private IAudioManager _audioManager;

    void Update ()
    {
        CheckNearbyEnemies();
    }

    private void CheckNearbyEnemies ()
    {
        if (_model == null) return;
        if (_model.IsMoving) return;
        if (!_model.IsAlive) return;
        if (Time.time < (_model.LastAttackTime + _model.EquippedWeapon.AttackCoolDown)) return;
        _closestEnemy = _levelManager.GetClosestEnemy(_view.MoveableTransform.position);
        if (_closestEnemy != null && _model.IsEnemyInRange(GetPositionTransform(), _closestEnemy))
        {
            AttackClosestEnemy();
        }
    }

    public void Die()
    {
        _model.IsAlive = false;
        _view.PlayDieAnimation();
        EventBus.TriggerLevelFail();
    }

    public bool IsAlive()
    {
        return _model.IsAlive;
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public Transform GetPositionTransform()
    {
        return _view.MoveableTransform;
    }

    public void Initialize(IHeroModel model, SOHeroData data, ILevelManager levelManager, IWeaponsManager weaponManager, IAudioManager audioManager)
    {
        _model = model;
        _view = GetComponent(typeof(IHeroView)) as IHeroView;
        _view.Initialize();
        _weaponsManager = weaponManager;
        _levelManager = levelManager;
        _audioManager = audioManager;
        _model.HeroData = data;
        InitLife(data.HealthSO);

        EventBus.OnPlayerHealthBarLoaded += RegisterHealthBar;
        EventBus.TriggerOnPlayerInitialized();
    }

    private void RegisterHealthBar (IHealthBar healthbar)
    {
        _view.HealthBar = healthbar;
        _view.UpdateHealthBar(_model.Health / _model.MaxHealth);
    }


    private void OnDisable()
    {
        EventBus.OnPlayerHealthBarLoaded -= RegisterHealthBar;
    }

    public void EquipWeapon (SOHeroWeapon weapon)
    {
        _model.EquippedWeapon = weapon;
        _view.UpdateWeaponModel(_model.GetEquipedWeaponModel(_weaponsManager), _model.EquippedWeapon.MovementSpeedFactor, _model.EquippedWeapon.AttackSpeedFactor);
        EventBus.TriggerOnWeaponEquipped(weapon);
    }

    public void InitLife(SOHealth health)
    {
        _model.Health = health.MaxLife;
        _model.IsAlive = true;
        _model.MaxHealth = health.MaxLife;
    }

    public void SetIsMoving(bool moving)
    {
        if (!_model.IsAlive) return;
        _model.IsMoving = moving;
        _view.SetMovement(moving);
    }

    public void SetMovementDirection(float x, float y)
    {
        if (!_model.IsAlive) return;
        Vector3 moveVector = _model.GetMoveVector(x, y);
        float lookAngle = _model.GetLookAngle(x, y);
        _view.Move(moveVector, lookAngle);
    }

    public void TakeDamage(float damages)
    {
        if (!_model.IsAlive) return;
        _model.Health -= damages;
        _view.UpdateHealthBar(_model.Health / _model.MaxHealth);
        if (_model.Health <= 0)
        {
            Die();
        } else
        {
            _view.PlayHitAnimation();
        }
    }

    public void AttackClosestEnemy()
    {
        _view.PlayAttackAnimation(_closestEnemy);
        _model.LastAttackTime = Time.time;
    }

    public void ReceiveAnimatorEvent (EAnimationAction action)
    {
        if (action == EAnimationAction.Attack)
        {
            _closestEnemy.TakeDamage(_model.EquippedWeapon.Damages);
            _view.SpawnDamageHit(_closestEnemy, _model.EquippedWeapon);
            _audioManager.PlayAudioClip(EAudioClip.Hit);
        }
    }
}
