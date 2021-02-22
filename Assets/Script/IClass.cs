using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IClass : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public string type;
    public string weak;
    public bool isDef;

    protected int attackDamage;
    protected float attackRate;

    public void Awake() {
        animator = gameObject.GetComponent(typeof(Animator)) as Animator;
        //attackPoint = GameObject.Find("AttackPoint").transform;
        attackPoint = GetChildWithName(gameObject, "AttackPoint").transform;
        Initialise();
    }

    public static GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public float getAttackRate() {
        return attackRate;
    }

    public abstract void Initialise();
    public abstract void Attack(LayerMask ennemyLayers);
    public abstract void Defense(LayerMask ennemyLayers);

    public abstract void Delete();
}