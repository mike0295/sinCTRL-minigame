using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float maxX, minX, maxY, minY;

    private Transform target;


    void Awake()
    {
        target = GameObject.Find("player").transform;

    }

    private void Start()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), transform.position.y, transform.position.z);
    }


    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
