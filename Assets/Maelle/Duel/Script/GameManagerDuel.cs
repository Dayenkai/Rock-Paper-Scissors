using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerDuel : MonoBehaviour
{
    public CanvasManager player1,player2;
    public TextManager textm;
    public ButtonEffect play1, play2;

    void Start()
    {
        player1.ManageCanvas(false);
        player2.ManageCanvas(false);
        textm.TextEnable();
        
    }

    void Update()
    {
        if (!textm.isactive)
        {
            player1.ManageCanvas(true);
        }
        if(play1.confirm_button.interactable == false)
        {
            player1.ManageCanvas(false);
            player2.ManageCanvas(true);
        }
        if (play2.confirm_button.interactable == false)
        {
            player2.ManageCanvas(false);
            whowin(play1, play2) ;
        }

    }

    void whowin(ButtonEffect play1, ButtonEffect  play2)
    {
        if(play1.paper == true && play2.paper == true || play1.scissors == true && play2.scissors == true || play1.rock == true && play2.rock == true)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if(play1.paper == true && play2.rock == true || play1.scissors == true && play2.paper == true || play1.rock == true && play2.scissors == true)
        {
            SceneManager.LoadScene("Winner");
        }
        else
        {
            SceneManager.LoadScene("Winner2");
        }
    }

}
