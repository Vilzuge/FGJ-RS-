using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

  
    void FixedUpdate()
    {
        if (target)
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
