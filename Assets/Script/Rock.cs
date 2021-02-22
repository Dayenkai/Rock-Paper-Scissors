using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : IClass
{
    private float attackRange = 0.3f;
    private float default_speed;
    private float default_jump;
    private PlayerMovement pm;
    private CharacterController2D cc;
    private Animator aa;

    override public void Initialise()
    {
        pm = gameObject.GetComponent("PlayerMovement") as PlayerMovement;
        default_speed = pm.runSpeed;
        cc = gameObject.GetComponent("CharacterController2D") as CharacterController2D;
        aa = gameObject.GetComponent("Animator") as Animator;
        attackDamage = 30;
        attackRate = 10f;
        attackPoint.localPosition = new Vector3(1f, 0, 0);
        isDef = false;
        type = "Rock";
        weak = "Paper";
    }

    override public void Attack(LayerMask ennemyLayers)
    {
        if (!isDef)
        {
            animator.SetTrigger("IsAttacking");
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayers);

            foreach (Collider2D enemy in hitEnnemies)
            {
                enemy.GetComponent<PlayerController>().TakeDamage(attackDamage, type);
                enemy.GetComponent<Animator>().SetTrigger("IsHurt");
            }
        }
    }

    override public void Defense(LayerMask ennemyLayers)
    {
        if (!isDef)
        {
            default_speed = pm.runSpeed;
            default_jump = cc.m_JumpForce;
            pm.runSpeed = 0f;
            cc.m_JumpForce = 0f;
            isDef = true;
            animator.SetBool("IsDef", true);
        }
        else
        {
            Delete();
        }
    }

    override public void Delete()
    {
        pm.runSpeed = default_speed;
        cc.m_JumpForce = default_jump;
        isDef = false;
        animator.SetBool("IsDef", false);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
