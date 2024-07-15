using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroView : MonoBehaviour, IHeroView
{
    [SerializeField] Animator _animator;
    [SerializeField] Transform _rotatingTransform;
    [SerializeField] Transform _weaponSlot;

    public Transform MoveableTransform { get ; set; }

    private GameObject _weaponObject;


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
        _animator.SetTrigger(move ? AnimatorParameters.HERO_RUN : AnimatorParameters.HERO_IDLE);
    }

    public void UpdateHealthBar(float ratio)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateWeaponModel(GameObject weaponModel)
    {
        if (_weaponObject) Destroy(_weaponObject);
        _weaponObject = Instantiate(weaponModel, _weaponSlot);
        _weaponObject.transform.localPosition = new Vector3(0, 0, 0);
        _weaponObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
