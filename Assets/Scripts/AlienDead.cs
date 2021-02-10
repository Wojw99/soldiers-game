using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDead : MonoBehaviour
{
    public AudioClip deadSound1;
    public AudioClip deadSound2;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayDeadSound();
    }

    void PlayDeadSound()
    {
        int num = Random.Range(0, 3);

        if (num == 0)
        {
            audioSource.PlayOneShot(deadSound1);
        }
        else if(num == 1)
        {
            audioSource.PlayOneShot(deadSound2);
        }
    }
}
