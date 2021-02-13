using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool changeb = false;
    public static int bonus = 25;

    public int life = 0;
    public static int maxhealth = 100;
    //public Healthbar healthbar;

    private void Start()    
    {
        life = maxhealth;
        //healthbar.SetMaxHealth(maxhealth);
    }

    private void Update()
    {
        Bonus();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            life -= 10;
        }
        //healthbar.SetHealth(life);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0) Die();
    }

    void Die() {
        Debug.Log("Ennemy died !");
        Destroy(gameObject);
    }

    void Bonus()
    {
        if (Collect.lifebonus)
        {
            if (bonus + life < maxhealth)
            {
                life += bonus;
            }
            else
            {
                life = maxhealth;
            }

            Collect.lifebonus = false;
        }
        if (Collect.changebonus)
        {
            changeb = true;
            Collect.changebonus = false;
        }
    }
}
