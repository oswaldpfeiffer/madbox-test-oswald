using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOHeroWeapon", menuName = "ScriptableObjects/SOHeroWeapon", order = 6)]
public class SOHeroWeapon : ScriptableObject
{
    public string PrefabAddressable;
    public Sprite Preview;
    public float Damages;
    [Range(0.5f, 1.5f)]
    public float AttackSpeedFactor;
    public float AttackCoolDown;
    [Range(0.5f, 1.5f)]
    public float MovementSpeedFactor;
    public float AttackRange;
    public GameObject HitFX;
    public Color DamageHitColor;
}
