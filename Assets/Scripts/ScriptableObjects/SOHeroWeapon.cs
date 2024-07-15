using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOHeroWeapon", menuName = "ScriptableObjects/SOHeroWeapon", order = 6)]
public class SOHeroWeapon : ScriptableObject
{
    public string PrefabAddressable;
    public Sprite Preview;
    public float AttackSpeed;
    public float AttackInterval;
    public float MovementSpeed;
    public float AttackRange;
}
