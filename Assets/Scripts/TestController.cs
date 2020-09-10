using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    Rigidbody2D rb;
    float direction, horizontalMove;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");

        horizontalMove = direction * speed;


        rb.AddForce(new Vector2(horizontalMove, 0));

    }
}
