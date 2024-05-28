using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1.0f, bool destroyed = false)
    {
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        else 
            audioSrc.PlayOneShot(clip, volume);
    }
}
