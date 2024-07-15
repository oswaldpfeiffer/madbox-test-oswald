using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour, IHeroController
{
    private IHeroModel _model;
    private IHeroView _view;

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(IHeroModel model, SOHealth health)
    {
        _model = model;
        _view = GetComponent(typeof(IHeroView)) as IHeroView;
    }

    public void InitLife(SOHealth health)
    {
        throw new System.NotImplementedException();
    }

    public void SetIsMoving(bool moving)
    {
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
