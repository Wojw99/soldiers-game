using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int damage;
    public Sprite lastAnimationClip;
    public Sprite stoppingDamageAnimationClip;

    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (spriteRenderer.sprite == lastAnimationClip)
        {
            Destroy(gameObject);
        }
        else if (spriteRenderer.sprite == stoppingDamageAnimationClip)
        {
            circleCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyStatistics enemy = collision.GetComponent<EnemyStatistics>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
