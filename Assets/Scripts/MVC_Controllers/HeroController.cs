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
        if (_model != null && !_model.IsMoving)
        {
            _closestEnemy = _levelManager.GetClosestEnemy(_view.MoveableTransform.position);
        }
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public Transform GetPositionTransform()
    {
        return _view.MoveableTransform;
    }

    public void Initialize(IHeroModel model, SOHealth health, ILevelManager levelManager, IWeaponsManager weaponManager)
    {
        _model = model;
        _view = GetComponent(typeof(IHeroView)) as IHeroView;
        _view.Initialize();
        _weaponsManager = weaponManager;
        _levelManager = levelManager;
    }

    public void EquipWeapon (SOHeroWeapon weapon)
    {
        _model.EquippedWeapon = weapon;
        _view.UpdateWeaponModel(_model.GetEquipedWeaponModel(_weaponsManager));
    }

    public void InitLife(SOHealth health)
    {
        throw new System.NotImplementedException();
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

    public void TakeDamage(int damages)
    {
        throw new System.NotImplementedException();
    }
}
