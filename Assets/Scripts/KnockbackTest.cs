using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTest : MonoBehaviour
{
    Rigidbody2D rb;

    public float maxKnockbackTime, knockbackPower, knockbackSide;

    float direction, horizontalMove;
    public float speed;


    void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Knockback(maxKnockbackTime, knockbackPower, knockbackSide));
    }

    public IEnumerator Knockback(float maxKnockbackTime, float knockbackPower, float knockbackSide)
    {
        float timer = 0;

        while (maxKnockbackTime > timer)
        {
            timer += Time.deltaTime;

            rb.velocity = new Vector2(-knockbackSide, knockbackPower);
        }

        yield return 0;
    }
}
