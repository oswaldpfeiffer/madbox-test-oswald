using System;
using UnityEngine;

public interface IEnemyView : IView, IDamageableView
{
    void LookAtHero(IHeroController hero);
    void AddMoveVector(Vector3 v);
    void Attack(float damages);
}
