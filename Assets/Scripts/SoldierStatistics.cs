using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoldierStatistics : MonoBehaviour
{
    public int maxHealth;
    public int maxStamina;
    public GameObject healthBar;
    public GameObject staminaBar;
    public GameObject scoreText;
    public GameObject granade0Image;
    public GameObject granade1Image;
    public GameObject granade2Image;
    public GameObject deadEffect;
    public GameObject scoreWindow;
    public GameObject scoreWindowScore;
    public GameObject scoreWindowTime;

    public Bar health;
    public Bar stamina;
    public Bar exp;
    public int attack;
    public int score;
    public Granades granades;

    public static bool dead = false;

    TextMeshProUGUI textMesh;
    SoldierTimers soldierTimers;

    void Start()
    {
        textMesh = scoreText.GetComponent<TextMeshProUGUI>();
        soldierTimers = GetComponent<SoldierTimers>();
        score = 0;
        granades = new Granades(granade0Image, granade1Image, granade2Image);
        health = new Bar(maxHealth, healthBar);
        stamina = new Bar(maxStamina, staminaBar);
        UpdateScoreText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            health.GiveValue(-50);
        if (Input.GetKeyDown(KeyCode.E))
            health.GiveValue(20);
        if (health.CurrentValue <= 0)
            Dead();
        if (Input.GetKeyDown(KeyCode.R))
            Instantiate(deadEffect, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int value)
    {
        health.GiveValue(-1 * value);

        if(health.CurrentValue <= 0 && dead == false)
        {
            Dead();
            Debug.Log("dead");
        }
    }

    public void UpdateScoreText()
    {
        textMesh.text = score.ToString();
    }

    public void Dead()
    {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        EnemyBehaviour.active = false;
        EnemyArcherBehaviour.active = false;
        scoreWindow.SetActive(true);
        scoreWindowScore.GetComponent<TextMeshProUGUI>().text = score.ToString();
        scoreWindowTime.GetComponent<TextMeshProUGUI>().text = Mathf.Round(soldierTimers.gameTimer).ToString();
        gameObject.SetActive(false);
    }
}
