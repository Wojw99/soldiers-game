using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherBehaviour : MonoBehaviour
{
    public float offset;
    public float speed;
    public float followingDistance;
    public float stoppingDistance;
    public float shootingDistance;
    public float shootingForce;
    public GameObject shotPrefab;
    public GameObject shotStartPoint;
    public static bool active = true;

    float timeToAttack = 0;

    Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (active)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < followingDistance && distance > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }

            if (distance < shootingDistance && timeToAttack <= 0)
            {
                Shot();
            }

            if (timeToAttack > 0) timeToAttack -= Time.deltaTime;

            Rotate();
        }
    }
    
    void Shot()
    {
        Vector2 shotPosition = shotStartPoint.transform.position;
        GameObject shotObject = Instantiate(shotPrefab, new Vector3(shotPosition.x, shotPosition.y, 2f), transform.rotation);
        Projectile projectile = shotObject.GetComponent<Projectile>();

        projectile.LaunchToSoldier(shootingForce, playerTransform);

        AudioSystem.PlaySound(projectile.sound);

        timeToAttack = 1f;
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
