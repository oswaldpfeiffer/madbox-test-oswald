using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

    private Sequence _moveSeq;

    public void Initialize()
    {
        MoveableTransform = GetComponent<Transform>();
        if (HealthBarPrefab)
        {
            GameObject health = Instantiate(HealthBarPrefab, this.transform);
            HealthBar = health.GetComponent(typeof(IHealthBar)) as IHealthBar;
        }
    }

    public void StartReachTarget(Vector3 target, float duration, Action onCompleteCallback)
    {
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_MOVE);
        _moveSeq.Kill();
        MoveableTransform.DOMove(target, duration).SetEase(Ease.Linear).OnComplete(() => onCompleteCallback?.Invoke());
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
        _moveSeq.Kill();
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DAMAGE);
        _blinker.Blink();
    }

    public void PlayDieAnimation()
    {
        _moveSeq.Kill();
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DIE);
        _blinker.Blink();
    }

    private bool IsMeshVisible ()
    {
        return _skinnedMeshRenderer.isVisible;
    }

    public void Attack(IHeroController hero)
    {
        _rotatingTransform.LookAt(hero.GetPositionTransform());
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_ATTACK);
    }
}
