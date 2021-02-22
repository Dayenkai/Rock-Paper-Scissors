using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : IClass
{   
    private GameObject bulletPrefab;
    private GameObject shurikenPrefab;

    private GameObject gobj=null;

    private GameObject bu;
    private Bullet bullet;

    private bool defense_active = false;

    override public void Initialise() {
        attackRate = 3f;
        bulletPrefab = (GameObject) Resources.Load("Cissors_Attack") as GameObject;
        shurikenPrefab = (GameObject)Resources.Load("Scissors_defense") as GameObject;
        attackPoint.localPosition = new Vector3(1f, 0, 0);
        type = "Scissors";
        weak = "Rock";
    }

    override public void Attack(LayerMask ennemyLayers) 
    {
        if(defense_active == false)
        {
            bu = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);            
            bullet = bu.GetComponent("Bullet") as Bullet;
            bullet.type = type;
        }
        
    }

    override public void Defense(LayerMask ennemyLayers)
    {
        if(defense_active == false)
        {
            Launcher launcher;
            if(gobj != null)
            {
                Destroy(gobj);
            }
            gobj = Instantiate(shurikenPrefab, attackPoint.position, attackPoint.rotation);
            gobj.transform.parent = gameObject.transform;
            launcher = gobj.GetComponent("Launcher") as Launcher;
            launcher.go = gameObject;
            defense_active = true;
        }
        else
        {
            Destroy(gobj);
            defense_active = false;
        }
        
    }

    override public void Delete()
    {
        Destroy(gobj);
        defense_active = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, 0.1f);
    }
}
