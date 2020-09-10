    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMove : MonoBehaviour
{
    public float speed;
    public float jumpVelocity;

    public LayerMask platformLM;
    public CircleCollider2D cc;

    private Rigidbody2D rb;

    float direction;
    float horizontalMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (CheckDead()) {
            Debug.Log("DEAD");
            transform.position = new Vector3(-8, -1.9f, 0);
        }
    }

    private void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        horizontalMove = direction * speed;
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        if(IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }

    }

    private bool IsGrounded() {
        RaycastHit2D RC = Physics2D.CircleCast(cc.bounds.center, cc.radius*0.9f, Vector2.down, 0.1f, platformLM, 0, 0);

        return RC.collider != null;
    }

    private bool CheckDead() {
        if (transform.position.y < -6f) return true;
        else return false;
    }
}
