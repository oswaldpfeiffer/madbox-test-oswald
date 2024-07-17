using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOHeroData", menuName = "ScriptableObjects/SOHeroData", order = 8)]
public class SOHeroData : ScriptableObject
{
    public SOHealth HealthSO;
    public float MovementBaseSpeed;
}
