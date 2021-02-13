using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : IClass
{   
    private float attackRange = 0.3f;  

    override public void Initialise() {
        attackDamage = 30;
        attackRate = 10f;
        attackPoint.position += new Vector3(0.5f, 0, 0);
    }

    override public void Attack(LayerMask ennemyLayers) 
    {
        animator.SetTrigger("IsAttacking");
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayers);

        foreach(Collider2D enemy in hitEnnemies) {
            enemy.GetComponent<PlayerController>().TakeDamage(attackDamage);
            enemy.GetComponent<Animator>().SetTrigger("IsHurt");
        }
    }

    override public void Defense(LayerMask ennemyLayers)
    {

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
