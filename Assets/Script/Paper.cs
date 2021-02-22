using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : IClass
{
    private GameObject bulletPrefab;
    private GameObject defPrefab;
    private GameObject wall = null;

    private GameObject obj;
    private Bullet bullet;

    private bool wait = false;

    override public void Initialise() {
        attackRate = 2f;
        bulletPrefab = (GameObject) Resources.Load("Paper_Attack") as GameObject;
        defPrefab = (GameObject)Resources.Load("Paper_Defense") as GameObject;
        attackPoint.localPosition = new Vector3(1f, 0, 0);
        type = "Paper";
        weak = "Scissors";
    }

    override public void Attack(LayerMask ennemyLayers) 
    {
        obj = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        bullet = obj.GetComponent("Bullet") as Bullet;
        bullet.type = type;
    }

    override public void Defense(LayerMask ennemyLayers)
    {
        Launcher launcher;
        if (wall != null) Destroy(wall);
        wall = Instantiate(defPrefab, attackPoint.position, attackPoint.rotation);
        launcher = wall.GetComponent("Launcher") as Launcher;
        launcher.go = gameObject;
    }

    override public void Delete()
    {
        Destroy(wall);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, 0.1f);
    }
}
