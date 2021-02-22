using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject playerP;
    public Transform spawnP;

    void Start()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public void RespawnP(int health, Color color, string tagg)
    {
        GameObject child;

        Vector3 pos = spawnP.position;

        playerP = (GameObject)Resources.Load("Player") as GameObject;
        GameObject new_player = Instantiate(playerP, pos , spawnP.rotation);

        new_player.GetComponent<PlayerController>().maxhealth = health;
        new_player.tag = tagg;  

        child = GetChildWithName(new_player, "Pointer");
        child = GetChildWithName(child, "Pointer_player");
        child.GetComponent<Player_pointer>().color = color;

        //mode multiplayer online, type
        //GameObject.Find("Current_type").GetComponent<Type>().player = new_player;

    }

    public static void Fall (GameObject player, int damage)
    {
        int health_player;
        Color color_player;
        GameObject child;

        health_player = player.GetComponent<PlayerController>().life - damage;
        child = GetChildWithName(player, "Pointer");
        child = GetChildWithName(child, "Pointer_player");

        color_player = child.GetComponent<Player_pointer>().fill.color;

        gm.RespawnP(health_player, color_player, player.tag);
        KillPlayer(player);
    }

    public static void KillPlayer(GameObject player)
    {
        Destroy(player);
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

}
