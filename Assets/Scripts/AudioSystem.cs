using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioClip startSound;
    static AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        AudioSystem.Play(startSound);
    }

    public static void Play(AudioClip clip)
    {
        if (source != null)
        {
            source.PlayOneShot(clip);
        }
        
    }
}
