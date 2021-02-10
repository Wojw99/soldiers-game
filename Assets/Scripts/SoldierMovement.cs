using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public int speed;
    public int sprintSpeed;
    public Camera mainCamera;
    public float offset;

    Rigidbody2D rBody2D;
    SoldierStatistics statistics;

    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        statistics = GetComponent<SoldierStatistics>();
    }

    void Update()
    {
        Rotate();
        Dash();
        Move();
        rBody2D.velocity = Vector2.zero;
    }

    void Dash()
    {

    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.LeftShift) && statistics.stamina.CurrentValue > 1)
        {
            position += move * (sprintSpeed) * Time.deltaTime;
            statistics.stamina.GiveValue(-1f);
        }
        else if (!statistics.stamina.IsFull())
        {
            position += move * speed * Time.deltaTime;
            statistics.stamina.GiveValue(0.5f);
        }
        else
        {
            position += move * speed * Time.deltaTime;
        }

        transform.position = position;
    }

    void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+offset));
    }
}
