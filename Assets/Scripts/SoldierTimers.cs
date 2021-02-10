using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierTimers : MonoBehaviour
{
    public float timeToSwitchAmmo;
    public float gameTimer;
    public GameObject ammoBarObject;
    public GameObject timeText;

    SoldierShooting soldierShooting;
    TextMeshProUGUI textMesh;
    Bar ammoBar;
    float timeAmmo; 

    void Start()
    {
        soldierShooting = GetComponent<SoldierShooting>();
        textMesh = timeText.GetComponent<TextMeshProUGUI>();
        timeAmmo = timeToSwitchAmmo;
        gameTimer = 0f; 
        ammoBar = new Bar(timeToSwitchAmmo, ammoBarObject);
    }

    void Update()
    {
        gameTimer += Time.deltaTime;
        textMesh.text = Mathf.Round(gameTimer).ToString();

        if (timeAmmo <= 0)
        {
            soldierShooting.shotPrefab = soldierShooting.defaultShotPrefab;
            timeAmmo = timeToSwitchAmmo;
            ammoBar.Restart();
            ammoBarObject.SetActive(false);
        }
        else if(soldierShooting.shotPrefab != soldierShooting.defaultShotPrefab)
        {
            timeAmmo -= Time.deltaTime;
            ammoBar.GiveValue(-Time.deltaTime);
            if (!ammoBarObject.activeSelf) ammoBarObject.SetActive(true);
        }
    }

    public void Restart()
    {
        timeAmmo = timeToSwitchAmmo;
        ammoBar.Restart();
    }
}
