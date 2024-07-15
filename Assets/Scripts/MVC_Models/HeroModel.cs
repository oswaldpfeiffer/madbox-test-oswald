using UnityEngine;

public class HeroModel : IHeroModel
{
    public float Health { get; set; }
    public bool IsAlive { get; set; }
    public bool IsMoving { get ; set ; }
    public SOHeroWeapon EquippedWeapon { get ; set ; }

    public Vector3 GetMoveVector(float x, float y)
    {
       float speed = EquippedWeapon == null ? 0 : EquippedWeapon.MovementSpeed;
       return new Vector3(x, 0, y).normalized * Time.deltaTime * speed;
    }

    public float GetLookAngle (float x, float y)
    {
        float angleInRadians = Mathf.Atan2(x, y);
        return angleInRadians* Mathf.Rad2Deg;
    }

    public GameObject GetEquipedWeaponModel(IWeaponsManager weaponManager)
    {
        if (EquippedWeapon == null) return null;
        return weaponManager.GetModelForWeaponSO(EquippedWeapon);
    }

    public bool IsEnemyInRange(Transform hero, IEnemyController enemy)
    {
        float dist = (hero.transform.position - enemy.GetPositionTransform().transform.position).magnitude;
        if (EquippedWeapon == null) return false;
        return dist <= EquippedWeapon.AttackRange;
    }
}
