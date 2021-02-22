using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonEffect : MonoBehaviour
{

    public bool scissors = false;
    public bool paper = false;
    public bool rock = false;

    public bool end = false;

    public Button sc_button, pap_button, rock_button, confirm_button;

    void Start()
    {
        sc_button.onClick.AddListener(scissoreffect);
        pap_button.onClick.AddListener(papereffect);
        rock_button.onClick.AddListener(rockeffect);
        confirm_button.onClick.AddListener(confirm);
    }

    void scissoreffect()
    {
        scissors = true;
        paper = false;
        rock = false;
        Debug.Log("scissors");
        Debug.Log(scissors);
        Debug.Log(paper);
        Debug.Log(rock);
    }

    void papereffect()
    {
        scissors = false;
        paper = true;
        rock = false;
        Debug.Log("paper");
        Debug.Log(scissors);
        Debug.Log(paper);
        Debug.Log(rock);
    }

    void rockeffect()
    {
        scissors = false;
        paper = false;
        rock = true;
        Debug.Log("rock");
        Debug.Log(scissors);
        Debug.Log(paper);
        Debug.Log(rock);
    }

    void confirm()
    {
        sc_button.interactable = false;
        pap_button.interactable = false;
        rock_button.interactable = false;
        confirm_button.interactable = false;    
    }

}
