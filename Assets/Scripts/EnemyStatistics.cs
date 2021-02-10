using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistics : MonoBehaviour
{
    public int maxHealth;
    public int attack;
    public int scoreForKill;
    public Sprite enemyDeadSprite;
    public Sprite enemyWoundedSprite;
    public Sprite enemyVeryWoundedSprite;
    public GameObject enemyDeadPrefab;
    public AudioClip deadSound1;
    public AudioClip deadSound2;
    public GameObject bloodExplodePrefab;

    int currentHealth;

    SpriteRenderer spriteRenderer;
    SoldierStatistics soldierStatistics; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        soldierStatistics = GameObject.FindGameObjectWithTag("Player").GetComponent<SoldierStatistics>();
        currentHealth = maxHealth;
    }

    void PlayDeadSound()
    {
        int num = Random.Range(0, 3);

        if(num == 0)
        {
            AudioSystem.PlaySound(deadSound1);
        }
        else if(num == 1)
        {
            AudioSystem.PlaySound(deadSound2);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            //PlayDeadSound();

            soldierStatistics.score += scoreForKill;
            soldierStatistics.UpdateScoreText();

            Instantiate(bloodExplodePrefab, new Vector3(transform.position.x, transform.position.y, bloodExplodePrefab.transform.position.z), transform.rotation);
            Instantiate(enemyDeadPrefab, new Vector3(transform.position.x, transform.position.y, 3f), transform.rotation);

            Destroy(gameObject);
        }
        else if (currentHealth < 40 * maxHealth / 100)
        {
            spriteRenderer.sprite = enemyVeryWoundedSprite;
        }
        else if (currentHealth < 80 * maxHealth / 100)
        {
            spriteRenderer.sprite = enemyWoundedSprite;
        }
    }
}
