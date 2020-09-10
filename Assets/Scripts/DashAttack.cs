using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float direction;
    private int isDashing;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        dashTime = startDashTime;
        isDashing = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");

        if(isDashing==0) {
            if (Input.GetKeyDown("o")) isDashing++;
        } else { 
            if (dashTime<=0) {
                isDashing--;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;

            }
            else {
                dashTime -= Time.deltaTime;

                if (isDashing == 1) {
                    rb.velocity = new Vector2(direction * dashSpeed, 0);
                }
            }


        }
    }
}
