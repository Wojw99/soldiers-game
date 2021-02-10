using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    Transform targetTransform;

    void Start()
    {
        targetTransform = target.GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
    }
}
