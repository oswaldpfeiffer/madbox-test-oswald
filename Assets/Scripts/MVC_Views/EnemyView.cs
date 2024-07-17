using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour, IEnemyView
{
    [SerializeField] Transform _rotatingTransform;
    public Transform MoveableTransform { get; set; }
    [SerializeField] Animator _animator;
    [SerializeField] SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] Blinker _blinker;

    [SerializeField] GameObject HealthBarPrefab;
    public IHealthBar HealthBar { get; set; }

    public void Initialize()
    {
        MoveableTransform = GetComponent<Transform>();
        if (HealthBarPrefab)
        {
            GameObject health = Instantiate(HealthBarPrefab, this.transform);
            HealthBar = health.GetComponent(typeof(IHealthBar)) as IHealthBar;
        }
    }

    public void LookAtHero(IHeroController hero)
    {
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
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DIE);
        _blinker.Blink();
    }

    private bool IsMeshVisible ()
    {
        return _skinnedMeshRenderer.isVisible;
    }
}
