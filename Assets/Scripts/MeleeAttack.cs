using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public int meleeStack; //used for animation

    public float attackDelay;
    private float tempAttackDelay;

    public float attackDuration;
    private float tempAttackDuration;

    public bool isMeleeAttacking;
    public bool canMeleeAttack;

    void Start()
    {
        tempAttackDelay = 0.0f;
        meleeStack = 0;
    }

    void Update()
    {
        DoMeleeAttack();

        if (isMeleeAttacking) transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        else transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
    }

    private void DoMeleeAttack()
    {

        if (tempAttackDelay <= 0.01f && tempAttackDuration <= 0.01f)
        {
            isMeleeAttacking = false;

            if (Input.GetKeyDown("i") && meleeStack == 0)
            {
                tempAttackDelay = attackDelay;
                tempAttackDuration = attackDuration;
                isMeleeAttacking = true;
                meleeStack++;
            }
            else if (Input.GetKeyDown("i") && meleeStack == 1)
            {
                tempAttackDelay = attackDelay;
                tempAttackDuration = attackDuration;
                isMeleeAttacking = true;
                meleeStack--;
            }
        }
        else
        {
            if(tempAttackDelay <= 0.01f && tempAttackDuration >= 0.01f) {
                isMeleeAttacking = false;
            }

            tempAttackDelay -= Time.deltaTime;
            tempAttackDuration -= Time.deltaTime;
        }
    }
}
