using UnityEngine;

public interface IHeroModel : IModel, IDamageableModel
{
    bool IsMoving { get; set; }
    float LastAttackTime { get; set; }
    SOHeroData HeroData { get; set; }
    SOHeroWeapon EquippedWeapon { get; set; }
    GameObject GetEquipedWeaponModel(IWeaponsManager weaponManager);
    Vector3 GetMoveVector(float x, float y);
    float GetLookAngle(float x, float y);
    bool IsEnemyInRange(Transform hero, IEnemyController enemy);
}
