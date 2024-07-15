using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOAudioClip", menuName = "ScriptableObjects/SOAudioClip", order = 0)]
public class SOAudioClip : ScriptableObject
{
    public EAudioClip ClipEnum;
    public AudioClip Clip;
    [Range(0.1f,1f)]
    public float Volume = 1;
}
