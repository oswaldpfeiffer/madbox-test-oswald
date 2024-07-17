using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour, IEnemyView
{
    [SerializeField] Transform _rotatingTransform;
    public Transform MoveableTransform { get; set; }
    [SerializeField] Animator _animator;

    public void DisplayHealthBar(bool display)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        MoveableTransform = GetComponent<Transform>();
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
        throw new System.NotImplementedException();
    }


    public void PlayHitAnimation()
    {
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DAMAGE);
    }

    public void PlayDieAnimation()
    {
        _animator.SetTrigger(AnimatorParameters.ENEMY_BEE_DIE);
    }
}
