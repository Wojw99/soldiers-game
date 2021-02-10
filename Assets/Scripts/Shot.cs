using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Shooting : MonoBehaviour
{
    public Sprite shootingSoldierSprite;
    public Sprite commonSoldierSprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spriteRenderer.sprite = shootingSoldierSprite;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            spriteRenderer.sprite = commonSoldierSprite;
        }
    }

}
