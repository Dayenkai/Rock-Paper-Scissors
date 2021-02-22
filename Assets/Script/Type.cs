using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public GameManager gm;

    public Image current;
    public Image second;

    public string currentclass;
    public string secondclass;

    private string cur;
    private string sec;

    public GameObject player;
    public SpriteLoader loader;


    private void Update()
    {
        if (player)
        {
            currentclass = player.GetComponent<PlayerCombat>().player.type;
            secondclass = player.GetComponent<PlayerCombat>().alt_player.type;
        }

        if (cur != currentclass )
        {
            current.sprite = GetSprite(currentclass);
            cur = currentclass;
        }
        if (sec != secondclass)
        {
            second.sprite = GetSprite(secondclass);
            sec = secondclass;
        }

    }

    public Sprite GetSprite(string classe)
    {
        switch (classe)
        {
            default:
            case "Paper":     
                return SpriteLoader.Instance.PaperSp;
            case "Rock":     
                return SpriteLoader.Instance.RockSp;
            case "Scissors":     
                return SpriteLoader.Instance.ScissorsSp;

        }

    }
}
