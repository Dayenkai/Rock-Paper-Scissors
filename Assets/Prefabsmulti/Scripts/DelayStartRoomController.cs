using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStartRoomController : MonoBehaviourPunCallbacks
{
    //scene navigation index
    [SerializeField]
    private int waitingRoomSceneIndex;

    public override void OnEnable()
    {
        //register to photon callback functions
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        //unregister to photon callback functions
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom() //Callback function for when we succefully create a room
    {
        //called when our pplayer joins the room
        // load into waiting room scene
        SceneManager.LoadScene(waitingRoomSceneIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
