using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView PV;
    public int charactervalue;
    public GameObject myCharacter;

    public int playerHealth;
    public int playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        Debug.Log("the character number is " + whichCharacter);
        charactervalue = whichCharacter;
        myCharacter = Instantiate(PlayerInfo.PI.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }

}
