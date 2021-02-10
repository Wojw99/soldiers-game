using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Sprite lastAnimationClip;
    public AudioClip burstSound1;
    public AudioClip burstSound2;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        PlayDeadSound();
    }

    void Update()
    {
        if (spriteRenderer.sprite == lastAnimationClip)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
            Destroy(gameObject, 3f);
        }
    }

    void PlayDeadSound()
    {
        int num = Random.Range(0, 2);

        if (num == 0)
        {
            audioSource.PlayOneShot(burstSound1);
        }
        else if (num == 1)
        {
            audioSource.PlayOneShot(burstSound2);
        }
    }
}
