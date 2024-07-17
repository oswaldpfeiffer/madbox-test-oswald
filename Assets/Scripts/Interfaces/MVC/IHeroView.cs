using UnityEngine;

public interface IHeroView : IView, IDamageableView
{
    void Move(Vector3 moveVec, float rotationAngle);
    void SetMovement(bool move);
    void UpdateWeaponModel(GameObject weaponModel, float movementSpeedFactor, float attackSpeedFactor);
    void PlayAttackAnimation(IEnemyController enemy);
    void SpawnDamageHit(IDamageableController controller, SOHeroWeapon weapon);
}
