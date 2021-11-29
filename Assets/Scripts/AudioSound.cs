using UnityEngine;
using UnityEngine.Audio;

// Serialized class that gets called for the
[System.Serializable]
public class AudioSound 
{
    public string name;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
