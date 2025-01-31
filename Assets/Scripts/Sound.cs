﻿using UnityEngine;


[CreateAssetMenu(menuName = "Tower Box/Sound", fileName = "sound.asset")]
public class Sound : ScriptableObject
{
    [System.Serializable]
    public enum SoundType
    { 
        MUSIC, FX
    }
    public SoundType soundType;
    public AudioClip clip;
    [Range(0, 1f)]
    public float volume;
    public bool loop;

}
