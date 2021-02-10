using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public GameObject burst;
    public float force;

    Rigidbody2D rbody2D;

    void Awake()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    public void LaunchToTarget(Vector2 target)
    {
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

        rbody2D.velocity = (myPos - target).normalized * force * (-1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(burst, new Vector3(transform.position.x, transform.position.y, burst.transform.position.z), Quaternion.identity);
        Destroy(gameObject, 0.05f);
    }

}
