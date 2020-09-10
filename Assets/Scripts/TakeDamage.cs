using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    GameObject player;
    Player playerStats;
    Rigidbody2D rb;
    BoxCollider2D bc;
    
    public float knockbackSide, knockbackUp, maxKnockbackTime, knockbackPower;
    private int knockbackDirection;

    private float timerInvincible;

    public float invincibleTime;
        
    public bool isInvincible;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<Player>();
        rb = player.GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }


    private void Start()
    {
        isInvincible = false;
        timerInvincible = 0f;
    }


    private void Update()
    {
        if (isInvincible) { 
            if (timerInvincible > invincibleTime) {
                isInvincible = false;
            } else {
                timerInvincible += Time.deltaTime;
            }
        }

        if (!isInvincible) bc.enabled = true;
        else {
            bc.enabled = false;
            GetComponentInParent<Animation>().Play("player_hurt"); 
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.layer == 11 && !isInvincible) {
            isInvincible = true;
            timerInvincible = 0f;
            playerStats.DamagePlayer(20);



            //StartCoroutine(Invincible());

           /* rb.velocity = Vector2.zero;


            if (collision.transform.position.x > player.transform.position.x) knockbackDirection = -1;
            else knockbackDirection = 1;

            StartCoroutine(Knockback(maxKnockbackTime, knockbackPower, player.transform.position));

            isInvincible = false;
            */
        }
    } 

    /*
    public IEnumerator Invincible() {
        timerInvincible = 0;

        if (invincibleTime <= timerInvincible) isInvincible = false;

        while (invincibleTime > timerInvincible) {
            timerInvincible += Time.deltaTime;
            isInvincible = true;
        }


        
        yield return 0;
    }

    public IEnumerator Knockback(float maxKnockbackTime, float knockbackPower, Vector3 knockbackDirection) {
        timer = 0;

        while (maxKnockbackTime > timer) {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockbackDirection.x * -100, -knockbackDirection.y + knockbackPower, player.transform.position.z));
        }

        yield return 0;
    }*/
}
