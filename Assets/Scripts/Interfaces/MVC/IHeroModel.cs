using UnityEngine;

public interface IHeroModel : IModel, IDamageableModel
{
    bool IsMoving { get; set; }
    SOHeroWeapon EquippedWeapon { get; set; }
    GameObject GetEquipedWeaponModel(IWeaponsManager weaponManager);
    Vector3 GetMoveVector(float x, float y);
    float GetLookAngle(float x, float y);
}
