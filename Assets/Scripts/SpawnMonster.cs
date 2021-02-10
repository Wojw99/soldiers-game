using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    public GameObject archer;
    public GameObject monsterStronger;
    public GameObject monsterTheStrongest;
    public float timeBetweenSpawn;
    public float timeReduction;

    float timeToSpawn = 0f;
    float nextTimeReduction = 60f;
    float nextTimeBetweenSpawn = 9f;

    private void Start()
    {
        EnemyBehaviour.active = true;
        EnemyArcherBehaviour.active = true;
        nextTimeReduction = timeReduction;
        nextTimeBetweenSpawn = timeBetweenSpawn;
    }

    void Update()
    {
        if(nextTimeReduction < 0 && nextTimeBetweenSpawn > 1)
        {
            nextTimeBetweenSpawn -= 1f;
            nextTimeReduction = timeReduction;
        }
        else
        {
            nextTimeReduction -= Time.deltaTime;
        }

        if (timeToSpawn < 0)
        {
            SpawnAlien();
            timeToSpawn = nextTimeBetweenSpawn;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }

    void SpawnAlien()
    {
        int num = Random.Range(0, 6);

        if(nextTimeBetweenSpawn < 0.6 * timeBetweenSpawn && num == 1)
        {
            Instantiate(monsterStronger, transform.position, Quaternion.identity);
        }
        else if(nextTimeBetweenSpawn < 0.4 * timeBetweenSpawn && num == 0)
        {
            Instantiate(monsterTheStrongest, transform.position, Quaternion.identity);
        }
        else if(num == 2)
        {
            Instantiate(archer, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(monster, transform.position, Quaternion.identity);
        }
    }
}
