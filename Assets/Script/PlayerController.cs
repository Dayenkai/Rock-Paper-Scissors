using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int bonus = 25;

    public int maxhealth = 100;
    public int life = 0;
    public Healthbar healthbar;

    public int damagefall = 20;

    private void Start()
    {
        life = maxhealth;
        if (healthbar != null)
        {
            healthbar.SetMaxHealth(maxhealth);
        }
    }

    public void TakeDamage(int damage, string type)
    {
        int dmg;
        PlayerCombat myClass = gameObject.GetComponent("PlayerCombat") as PlayerCombat;
        if (gameObject.tag == "J1" || gameObject.tag == "J2" || gameObject.tag == "J3")
        {
            if (myClass.player.weak == type)
            {
                dmg = damage;
            }
            else if (myClass.player.type == type)
            {
                dmg = 0;
            }
            else
            {
                dmg = damage / 2;
            }

            life -= dmg;

            if (life <= 0) GameManager.KillPlayer(gameObject);
        }
        else
        {
            Launcher launcher = gameObject.GetComponent("Launcher") as Launcher;
            myClass = launcher.go.GetComponent("PlayerCombat") as PlayerCombat;
            if (myClass.player.weak == type)
            {
                myClass.player.Delete();
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            life -= 10;
        }

        if (healthbar != null)
        {
            healthbar.SetHealth(life);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("End");
            Application.Quit();
        }

        if (transform.position.y <= -1)
        {
            GameManager.Fall(gameObject, damagefall);
        }

        if (life <= 0)
        {
            GameManager.KillPlayer(gameObject);

        }
    } 
}
