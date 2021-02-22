using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button play, exit;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(startPlay);
        exit.onClick.AddListener(exitGame);
    }

    void startPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }


    void exitGame()
    {
        Debug.Log("End");
        Application.Quit();
    }

}
