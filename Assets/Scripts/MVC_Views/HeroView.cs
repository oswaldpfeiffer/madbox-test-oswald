using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroView : MonoBehaviour, IHeroView
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _rotatingTransform;
    [SerializeField] Transform _weaponSlot;
    [SerializeField] HitSpawner _hitSpawner;

    public Transform MoveableTransform { get ; set; }

    private GameObject _weaponObject;

    public IHealthBar HealthBar { get; set; }

    

    public void DisplayHealthBar(bool display)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        MoveableTransform = GetComponent<Transform>();
    }

    public void Move(Vector3 vec, float rotationAngle)
    {
        MoveableTransform.position += vec;
        _rotatingTransform.localEulerAngles = new Vector3(0, rotationAngle, 0);
    }

    public void SetMovement(bool move)
    {
        AnimatorUtil.ResetAnimatorTriggers(_animator);
        _animator.SetTrigger(move ? AnimatorParameters.HERO_RUN : AnimatorParameters.HERO_IDLE);
    }

    public void UpdateHealthBar(float ratio)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateWeaponModel(GameObject weaponModel, float movementSpeedFactor, float attackSpeedFactor)
    {
        if (_weaponObject) Destroy(_weaponObject);
        _weaponObject = Instantiate(weaponModel, _weaponSlot);
        _weaponObject.transform.localPosition = new Vector3(0, 0, 0);
        _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        _animator.SetFloat(AnimatorParameters.HERO_MOVESPEEDFACTOR, movementSpeedFactor);
        _animator.SetFloat(AnimatorParameters.HERO_ATTACKSPEEDFACTOR, attackSpeedFactor);
    }

    public void PlayAttackAnimation (IEnemyController enemy)
    {
        _rotatingTransform.LookAt(enemy.GetPositionTransform());
        _animator.SetTrigger(AnimatorParameters.HERO_ATTACK);
    }

    public void PlayHitAnimation ()
    {
        
    }

    public void PlayDieAnimation()
    {

    }

    public void SpawnDamageHit (IDamageableController controller, SOHeroWeapon weapon)
    {
        _hitSpawner.Spawn(controller, weapon);
    }
}
