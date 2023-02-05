using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup group;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;
    public bool playOnAwake;

    [Header("3D Audio Settings")]
    public bool isSpatialAudio;

    [Range(0f, 1f)]
    public float spatialBlend = 0f;

    public AudioRolloffMode volumeRolloff;

    public float spread;
    public float minDistance;
    public float maxDistance;

    [HideInInspector]
    public AudioSource source;
}
