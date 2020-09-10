using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    public float jumpVelocity;
    public float dbJumpVelocity;

    public bool isDropAttack;
    public float dropVelocity;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public bool isDashing;

    public float camShakeAmt;

    BoxCollider2D player_DamageTrigger;


    public LayerMask platformLayerMask;
    public Animator animator;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    BoxCollider2D dashTrigger;
    BoxCollider2D dropTrigger;


    CameraShake camShake;

    float horizontalMove = 0f;
    float direction;
    bool facingRight = true;


    bool isJumping;
    bool doubleJump = false;

    public float dashCool;
    public static float timeUntilDash;

    public float dropCool;
    public static float timeUntilDrop;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        player_DamageTrigger = GameObject.FindGameObjectWithTag("PlayerTrigger").GetComponent<BoxCollider2D>();
        dashTrigger = GameObject.FindGameObjectWithTag("Dash").GetComponent<BoxCollider2D>();
        dropTrigger = GameObject.FindGameObjectWithTag("Drop").GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        dashTime = startDashTime;
        isDashing = false;
        dashTrigger.enabled = false;
        dropTrigger.enabled = false;
        timeUntilDash = 0f;
        timeUntilDrop = 0f;


        camShake = Camera.main.GetComponent<CameraShake>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetFloat("verticalSpeed", rb.velocity.y);
        animator.SetBool("isDashing", isDashing);

        if (isDashing || isDropAttack) player_DamageTrigger.enabled = false;
        if (isDropAttack) dropTrigger.enabled = true;


    }

    private void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");

        horizontalMove = direction*speed;


        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        if (direction>0 && !facingRight) Flip();
        else if (direction<0 && facingRight) Flip();

        if (isDropAttack)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if(IsGrounded()) {
                camShake.Shake(camShakeAmt, 0.2f);
                player_DamageTrigger.enabled = true;
            }
        }

        if (IsGrounded()) {
            isJumping = false;
            animator.SetBool("isJumping", false);

            doubleJump = false;
            isDropAttack = false;
            dropTrigger.enabled = false;
        }

        DashAttack();


        
        if(isJumping && Input.GetKeyDown("w") && !doubleJump) {
            rb.velocity = new Vector2 (rb.velocity.x, dbJumpVelocity);
            doubleJump = true;
        }  

        if(IsGrounded() && Input.GetKeyDown("w")) {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown("p") && !isDropAttack && doubleJump && timeUntilDrop<0.01f)
        {
            DropAttack();
        }

        if (timeUntilDrop > 0.01f) timeUntilDrop -= Time.deltaTime; 
    
    }

    private void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool IsGrounded() {
        RaycastHit2D raycasthit2D = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, platformLayerMask);
        return raycasthit2D.collider != null; 
    }

    private void DropAttack() {
        isDropAttack = true;
        timeUntilDrop = dropCool;
        player_DamageTrigger.enabled = false;
        rb.velocity = new Vector2(0, -dropVelocity);
    }

    private void DashAttack() {
        if (!isDashing && timeUntilDash > 0.01f)
        {
            timeUntilDash -= Time.deltaTime;
        }
        else if (!isDashing && timeUntilDash < 0.01f)
        {
            timeUntilDash = 0f;

            if (Input.GetKeyDown("o"))
            {
                isDashing = true;
                dashTrigger.enabled = true;
                dropTrigger.enabled = false;

                camShake.Shake(camShakeAmt, 0.15f);
            }
        }
        else
        { //is dashing
            if (dashTime <= 0)
            {
                isDashing = false;
                player_DamageTrigger.enabled = true;
                dashTrigger.enabled = false;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                timeUntilDash = dashCool;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (isDashing)
                {
                    if (facingRight) rb.velocity = new Vector2(dashSpeed, 0);
                    else rb.velocity = new Vector2(-dashSpeed, 0);

                }

            }
        }
    }

}
