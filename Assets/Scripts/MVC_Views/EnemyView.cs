using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyView : MonoBehaviour, IEnemyView
{
    [SerializeField] Transform _rotatingTransform;
    public Transform MoveableTransform { get; set; }
    [SerializeField] Animator _animator;
    [SerializeField] SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] Blinker _blinker;

    [SerializeField] GameObject HealthBarPrefab;
    public IHealthBar HealthBar { get; set; }

    private IProjectileSpawner _projectileSpawner;

    public void Initialize()
    {
        MoveableTransform = GetComponent<Transform>();
        _projectileSpawner = GetComponent(typeof(IProjectileSpawner)) as IProjectileSpawner;
        if (HealthBarPrefab)
        {
            GameObject health = Instantiate(HealthBarPrefab, this.transform);
            HealthBar = health.GetComponent(typeof(IHealthBar)) as IHealthBar;
        }
    }

    public void AddMoveVector(Vector3 v)
    {
        MoveableTransform.position += v;
    }

    public void LookAtHero(IHeroController hero)
    {
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_IDLE);
        if (hero != null)
        {
            _rotatingTransform.LookAt(hero.GetPositionTransform());
        }
    }

    public void UpdateHealthBar(float ratio)
    {
        if (HealthBar != null)
        {
            HealthBar.SetFillAmount(ratio);
            HealthBar.SetVisible(ratio > 0 && IsMeshVisible());
        }
    }


    public void PlayHitAnimation()
    {
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DAMAGE);
        _blinker.Blink();
    }

    public void PlayDieAnimation()
    {
        AnimatorUtil.ResetAnimatorTriggers(_animator);
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DIE);
        _blinker.Blink();
    }

    private bool IsMeshVisible ()
    {
        return _skinnedMeshRenderer.isVisible;
    }

    public void Attack(float damages)
    {
        _projectileSpawner.Shoot(damages);
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_ATTACK);
    }
}
