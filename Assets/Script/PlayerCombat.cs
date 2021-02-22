using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public IClass player;
    public IClass alt_player;

    public Animator animator;
    public Transform attackPoint;
    public LayerMask ennemyLayers;
    float nextAttackTime = 0f;
    float nextDefenseTime = 2;

    private float left_start;
    private float right_start;
    private Bullet bullet;
    private GameObject bulletPrefab;
    private float temp;
    private float last_speed;

    
    void randClass() {
        int randomNumber = Random.Range(1, 4);
        switch(randomNumber) {
            case 1:
                player = gameObject.AddComponent<Rock>();
                break;
            
            case 2:
                player = gameObject.AddComponent<Paper>();
                break;
            
            default:
                player = gameObject.AddComponent<Scissors>();
                break;
        }
    }

    void Start() {
        randClass();
        alt_player = player;
        bulletPrefab = (GameObject) Resources.Load("Paper_Attack") as GameObject;
        bullet = bulletPrefab.GetComponent("Bullet") as Bullet;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.tag == "J1" || Input.GetKeyDown(KeyCode.S) && gameObject.tag == "J2" || Input.GetKeyDown(KeyCode.J) && gameObject.tag == "J3") {
            player.Delete();
            IClass temp = player;
            player = alt_player;
            alt_player = temp;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && gameObject.tag == "J1" || Input.GetKeyDown(KeyCode.A) && gameObject.tag == "J2" || Input.GetKeyDown(KeyCode.Y) && gameObject.tag == "J3")
            {
                left_start = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.RightShift) && gameObject.tag == "J1" || Input.GetKeyDown(KeyCode.E) && gameObject.tag == "J2" || Input.GetKeyDown(KeyCode.I) && gameObject.tag == "J3")
            {
                right_start = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.RightControl) && gameObject.tag == "J1" || Input.GetKeyUp(KeyCode.A) && gameObject.tag == "J2" || Input.GetKeyUp(KeyCode.Y) && gameObject.tag == "J3")
            {
                if (player.type == "Paper")
                {
                    temp = bullet.speed;
                    bullet.speed *= 1 + (Time.time - left_start) * 1.3f;
                    if (bullet.speed > 20f) bullet.speed = 20;
                    else if (bullet.speed < 5) bullet.speed = 5;
                }

                player.Attack(ennemyLayers);
                nextAttackTime = Time.time + 1f / player.getAttackRate();

                if (player.type == "Paper") bullet.speed = temp;
            }
            else if (Input.GetKeyUp(KeyCode.RightShift) && gameObject.tag == "J1" || Input.GetKeyUp(KeyCode.E) && gameObject.tag == "J2" || Input.GetKeyUp(KeyCode.I) && gameObject.tag == "J3")
            {
                player.Defense(ennemyLayers);
            }

        }
    }
}

