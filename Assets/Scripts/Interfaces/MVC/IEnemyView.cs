using System;
using UnityEngine;

public interface IEnemyView : IView, IDamageableView
{
    void LookAtHero(IHeroController hero);
    void StartReachTarget(Vector3 target, float duration, Action onCompleteCallback);
    void Attack(IHeroController hero);
}
