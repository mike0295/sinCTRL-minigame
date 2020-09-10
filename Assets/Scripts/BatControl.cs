using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    private Transform player;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;

    bool facingLeft = true;

    public float fastSpeed;
    private float speed;

    public float dashTime;
    public float slowTime;
    private float tempDashTime;
    private float tempSlowTime;

    private float distance;
    public float awareDistance;

    private bool isSlow;


    public float riseSpeed;

    private bool isWalking = true;
    public float walkSpeed;
    public float walkTime;
    private float tempWalkTime;
    public float restTime;
    private float tempRestTime;
    private int idleDirection = 1;

    private void Awake()
    {
        player = GameObject.Find("player").transform;
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isSlow = true;
        tempDashTime = dashTime;
        tempSlowTime = slowTime;
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        if (player == null) return;

        distance = Vector2.Distance(player.position, rb.position);
        speed = Mathf.Abs(rb.velocity.x);


        if (distance <= awareDistance)
        {
            FollowPlayer();
        }
        else
        {
            Idle();
        }

        if (rb.velocity.x > 0 && facingLeft) Flip();
        else if (rb.velocity.x < 0 && !facingLeft) Flip();

    }

    private void FollowPlayer()
    {
        if (isSlow)
        {
            if (tempSlowTime <= 0.01f)
            {
                isSlow = false;
                tempSlowTime = slowTime;
            }
            else
            {
                rb.velocity = new Vector2(0, riseSpeed);
                tempSlowTime -= Time.deltaTime;
            }
        }
        else
        {
            if (tempDashTime <= 0.01f)
            {
                isSlow = true;
                tempDashTime = dashTime;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, fastSpeed * Time.deltaTime);
                tempDashTime -= Time.deltaTime;
            }
        }
    }

    private void Idle()
    {
        if (isWalking)
        {
            if (tempWalkTime <= 0.01f)
            {
                isWalking = false;
                tempWalkTime = walkTime;

                if (idleDirection == 1) idleDirection = -1;
                else idleDirection = 1;

            }
            else
            {
                rb.velocity = new Vector2(idleDirection * walkSpeed, 0);
                tempWalkTime -= Time.deltaTime;
            }
        }
        else
        {
            if (tempRestTime <= 0.01f)
            {
                isWalking = true;
                tempRestTime = restTime;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                tempRestTime -= Time.deltaTime;
            }
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}

