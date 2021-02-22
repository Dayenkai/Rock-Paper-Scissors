using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public static bool lifebonus = false;
    public float time;

    public float amplitude = 0.05f;
    public float speed = 3f;
    private float tempVal;
    private Vector3 tempPos;

    BoxCollider2D bc;
    SpriteRenderer sr;

    public void Start()
    {
        tempPos.x = transform.position.x;
        tempVal = transform.position.y;
        time = 0;

        sr = gameObject.GetComponent<SpriteRenderer>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Active(bool boolean) {
        sr.enabled = boolean;
        bc.enabled = boolean;
    }

    public void Update()
    {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;

        if(!sr.enabled && Time.time - time > 4f) Active(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCombat user = collision.GetComponent<PlayerCombat>();
        PlayerController cp = collision.GetComponent<PlayerController>();

        if (user != null)
        {
            if (gameObject.tag == "Life")
            {
                
                cp.life += 25;
                time = Time.time;
                Active(false);
            }
            else
            {
                if ((!user.player.type.Equals(gameObject.tag)) && (!user.alt_player.type.Equals(gameObject.tag)))
                {
                    time = Time.time;
                    Active(false);
                    if (user.player != user.alt_player) Destroy(user.GetComponent(user.alt_player.type) as IClass);
                    switch (gameObject.tag)
                    {
                        case "Rock":
                            user.alt_player = user.gameObject.AddComponent<Rock>();
                            break;

                        case "Paper":
                            user.alt_player = user.gameObject.AddComponent<Paper>();
                            break;

                        case "Scissors":
                            user.alt_player = user.gameObject.AddComponent<Scissors>();
                            break;

                        default:
                            //do nothing
                            break;
                    }
                }
            }

        }
    }
}