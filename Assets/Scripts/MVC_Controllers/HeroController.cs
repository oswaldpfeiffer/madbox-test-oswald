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

    void Update ()
    {
        CheckNearbyEnemies();
    }

    private void CheckNearbyEnemies ()
    {
        if (_model == null) return;
        if (_model.IsMoving) return;
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

    public void Initialize(IHeroModel model, SOHeroData data, ILevelManager levelManager, IWeaponsManager weaponManager)
    {
        _model = model;
        _view = GetComponent(typeof(IHeroView)) as IHeroView;
        _view.Initialize();
        _weaponsManager = weaponManager;
        _levelManager = levelManager;
        _model.HeroData = data;
        InitLife(data.HealthSO);
    }

    public void EquipWeapon (SOHeroWeapon weapon)
    {
        _model.EquippedWeapon = weapon;
        _view.UpdateWeaponModel(_model.GetEquipedWeaponModel(_weaponsManager), _model.EquippedWeapon.MovementSpeedFactor, _model.EquippedWeapon.AttackSpeedFactor);
    }

    public void InitLife(SOHealth health)
    {
        _model.Health = health.MaxLife;
        _model.IsAlive = true;
        _model.MaxHealth = health.MaxLife;
    }

    public void SetIsMoving(bool moving)
    {
        _model.IsMoving = moving;
        _view.SetMovement(moving);
    }

    public void SetMovementDirection(float x, float y)
    {
        Vector3 moveVector = _model.GetMoveVector(x, y);
        float lookAngle = _model.GetLookAngle(x, y);
        _view.Move(moveVector, lookAngle);
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
        }
    }
}
