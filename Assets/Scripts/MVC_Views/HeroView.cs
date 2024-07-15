using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroView : MonoBehaviour, IHeroView
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _moveableTransform;
    [SerializeField] Transform _rotatingTransform;

    public void DisplayHealthBar(bool display)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector3 vec, float rotationAngle)
    {
        _moveableTransform.position += vec;
        _rotatingTransform.localEulerAngles = new Vector3(0, rotationAngle, 0);
    }

    public void SetMovement(bool move)
    {
        _animator.SetTrigger(move ? AnimatorParameters.HERO_RUN : AnimatorParameters.HERO_IDLE);
    }

    public void UpdateHealthBar(float ratio)
    {
        throw new System.NotImplementedException();
    }
}
