using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{

    PlayerMovement playerMovement;
    MeleeAttack meleeAttack;

    public Animator animator;

    private bool dash;

    void Start()
    {
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        meleeAttack = gameObject.GetComponentInParent<MeleeAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        dash = playerMovement.isDashing;
        if (dash) animator.SetBool("isDashing", true);
        else animator.SetBool("isDashing", false);

        animator.SetInteger("meleeStack", meleeAttack.meleeStack);
        animator.SetBool("isMeleeAttacking", meleeAttack.isMeleeAttacking);

        if(meleeAttack.isMeleeAttacking) { 
            
        }
    }



}
