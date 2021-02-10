using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    public GameObject addedShotPrefab;
    public AudioClip sound;

    private void Start()
    {
        RandomSpawn();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SoldierShooting soldier = collision.GetComponent<SoldierShooting>();
        SoldierTimers soldierTimers = collision.GetComponent<SoldierTimers>();
        CircleCollider2D collider2D = collision.GetComponent<CircleCollider2D>();

        if (soldier != null && collision.GetType() != collider2D.GetType())
        {
            soldier.shotPrefab = addedShotPrefab;
            soldierTimers.Restart();
            AudioSystem.PlaySound(sound);
            RandomSpawn();
        }
    }

    void RandomSpawn()
    {
        int randomX = Random.Range(-35, 35);
        int randomY = Random.Range(-28, 28);

        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }
}
