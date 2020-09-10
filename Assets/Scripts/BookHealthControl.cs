using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHealthControl : MonoBehaviour
{
    GameObject player;  
    MeleeAttack meleeAttack;
    Book book;
    Rigidbody2D rb;

    public float knockbackPower, knockbackTime;
    private int direction;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        meleeAttack = player.GetComponent<MeleeAttack>();
        book = GetComponentInParent<Book>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.transform.position.x >= transform.position.x) direction = -1;
        else direction = 1;

        if (collision.gameObject.CompareTag("Melee") && meleeAttack.isMeleeAttacking)
        {
            book.DamageBook(30);
            StartCoroutine(Knockback(direction, knockbackTime, 50));
        }
        else if (collision.gameObject.CompareTag("Dash"))
        {
            book.DamageBook(50);
            StartCoroutine(Knockback(direction, knockbackTime, 100));

        }
        else if (collision.gameObject.CompareTag("Drop"))
        {
            book.DamageBook(40);
            StartCoroutine(Knockback(direction, knockbackTime, 150));

        }
    }

    public IEnumerator Knockback(int direction, float maxKnockbackTime, float knockbackPower)
    {
        float timer = 0;

        while (maxKnockbackTime > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockbackPower * direction , 0, 0));
        }

        yield return 0;
    }
}
