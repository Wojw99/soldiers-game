using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    } 
}
