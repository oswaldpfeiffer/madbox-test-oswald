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

    public void TakeDamage(int damages)
    {
        throw new System.NotImplementedException();
    }
}
