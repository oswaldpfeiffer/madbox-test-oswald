using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject HitObject;

    public void Spawn(IDamageableController damageable, SOHeroWeapon weapon)
    {
        GameObject hitObj = Instantiate(HitObject);
        IHit hit = hitObj.GetComponent(typeof(IHit)) as IHit;
        hit.SetHit(damageable, weapon);

        GameObject ps = Instantiate(weapon.HitFX);
        ps.transform.position = damageable.GetPositionTransform().transform.position + new Vector3(0f, 0.5f, 0f);
    }
}
