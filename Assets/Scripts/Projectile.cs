using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public AudioClip sound;

    Rigidbody2D rbody2D;

    void Awake()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void LaunchToSoldier(float force, Transform player)
    {
        Vector2 target = player.position;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

        rbody2D.velocity = (myPos - target).normalized * force * (-1);
    }

    public void Launch(float force)
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

        Rotate();

        rbody2D.velocity = (myPos - target).normalized * force * (-1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyStatistics enemy = collision.collider.GetComponent<EnemyStatistics>();
        SoldierStatistics soldier = collision.collider.GetComponent<SoldierStatistics>();

        Destroy(gameObject);

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if(soldier != null)
        {
            soldier.TakeDamage(damage);
        }
    }

    void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + (-90)));
    }
}
