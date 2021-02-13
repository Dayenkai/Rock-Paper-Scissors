using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private IClass player;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask ennemyLayers;
    float nextAttackTime = 0f;
    
    void Start() {
        player = gameObject.AddComponent<Rock>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            
        }

        if(Time.time >= nextAttackTime) {
            if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) 
            {
                player.Attack(ennemyLayers);
                nextAttackTime = Time.time + 1f / player.getAttackRate();
            } 
            else if(Input.GetKeyDown(KeyCode.Mouse1)) {
                player.Defense(ennemyLayers);
            }
        }
    }
}
