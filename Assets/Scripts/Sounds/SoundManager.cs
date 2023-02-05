using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : SingletonPersistent<SoundManager>
{
    public Sound[] sounds;
    public AudioMixer mainMixer;

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            // Add all the non spatial audios to the gameobjet
            if (!s.isSpatialAudio)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.group;
            }
        }

        Play("BGM");

        Debug.Log("Play");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public AudioSource AddAudioSourceAndPlay(string soundName, GameObject reference)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }

        AudioSource source = reference.AddComponent<AudioSource>();
        //print($"Source Gameobject: {source.gameObject}");
        source.clip = s.clip;
        source.volume = s.volume;
        source.pitch = s.pitch;
        source.loop = s.loop;
        source.spatialBlend = s.spatialBlend;
        source.outputAudioMixerGroup = s.group;
        source.minDistance = s.minDistance;
        source.maxDistance = s.maxDistance;
        source.spread = s.spread;

        source.Play();

        return source;
    }

    public void SetMasterVolume(float value)
    {
        mainMixer.SetFloat("MasterVolume", value);
    }

    public void SetAmbienceVolume(float value)
    {
        mainMixer.SetFloat("AmbienceVolume", value);
    }

    public void SetSoundEffectsVolume(float value)
    {
        mainMixer.SetFloat("SoundEffectsVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        mainMixer.SetFloat("MusicVolume", value);
    }
}