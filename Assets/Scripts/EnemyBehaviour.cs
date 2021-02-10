using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float offset;
    public float speed;
    public float followingDistance;
    public float stoppingDistance;
    public static bool active = true;

    bool following = true;
    float timeToAttack = 0;

    Transform playerTransform;
    EnemyStatistics enemyStatistics;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyStatistics = GetComponent<EnemyStatistics>();
    }

    void Update()
    {
        if (active)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < followingDistance && following == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }

            if (timeToAttack > 0) timeToAttack -= Time.deltaTime;

            Rotate();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        SoldierStatistics soldier = collision.collider.GetComponent<SoldierStatistics>();

        if(soldier != null)
        {
            following = false;

            if(timeToAttack <= 0)
            {
                soldier.TakeDamage(enemyStatistics.attack);
                timeToAttack = 1f;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        following = true;
    }

    void Rotate()
    {
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(playerTransform.position);
        playerPosition.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        playerPosition.x -= objectPos.x;
        playerPosition.y -= objectPos.y;

        float angle = Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
}
