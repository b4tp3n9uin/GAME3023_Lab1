using UnityEngine.Audio;
using System;
using UnityEngine;

// Audio Manager Class for the Audio in this lab.
public class AudioManager : MonoBehaviour
{

    public AudioSound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
            
        DontDestroyOnLoad(gameObject);

        foreach (AudioSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Play sound
    public void Play(string name)
    {
        AudioSound s = Array.Find(sounds, sounds => sounds.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is NOT Found!");
            return;
        }

        s.source.Play();
    }

    // This function is mainly for looping the audio clips. like Walking, Driving or flying.
    public void LoopSound(string name)
    {
        AudioSound s = Array.Find(sounds, sounds => sounds.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is NOT Found!");
            return;
        }

        if (!s.source.isPlaying)
        {
            s.source.PlayOneShot(s.clip);
        }
    }

    // Stops Audio
    public void Stop(string name)
    {
        AudioSound s = Array.Find(sounds, sounds => sounds.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is NOT Found!");
            return;
        }

        s.source.Stop();
    }
}
