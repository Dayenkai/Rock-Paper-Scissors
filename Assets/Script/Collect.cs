using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public static bool lifebonus = false;
    public static bool changebonus = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if(player != null)
        {
            Destroy(gameObject);
            if(gameObject.tag == "Life")
            {
                lifebonus = true;
            }
            if (gameObject.tag == "Change")
            {
                changebonus = true;
            }
            
        }
    }
}
