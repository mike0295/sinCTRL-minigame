using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControl : MonoBehaviour
{


    private Rigidbody2D rb;
    private BoxCollider2D bc;

    bool facingRight = true;
    float direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    
    void LateUpdate()
    {
        direction = rb.velocity.x;

        if (direction > 0 && !facingRight) Flip();
        else if (direction < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
