using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealthBag : MonoBehaviour
{
    public int addedHealth;
    public AudioClip sound;

    void Start()
    {
        RandomSpawn();   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SoldierStatistics statistics = collision.GetComponent<SoldierStatistics>();
        CircleCollider2D collider2D = collision.GetComponent<CircleCollider2D>();

        if (statistics != null && collision.GetType() != collider2D.GetType())
        {
            if (!statistics.health.IsFull())
            {
                statistics.health.GiveValue(addedHealth);
                AudioSystem.PlaySound(sound);
                RandomSpawn();
            }
        }
    }

    void RandomSpawn()
    {
        int randomX = Random.Range(-35, 35);
        int randomY = Random.Range(-28, 28);

        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }
}
