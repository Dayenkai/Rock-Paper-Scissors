using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IClass : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    protected int attackDamage;
    protected float attackRate;

    public void Start() {
        animator = gameObject.GetComponent(typeof(Animator)) as Animator;
        attackPoint = GameObject.Find("AttackPoint").transform;
        Initialise();
    }

    public float getAttackRate() {
        return attackRate;
    }

    public abstract void Initialise();
    public abstract void Attack(LayerMask ennemyLayers);
    public abstract void Defense(LayerMask ennemyLayers); 
}