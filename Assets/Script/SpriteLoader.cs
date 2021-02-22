using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public static SpriteLoader Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite PaperSp;
    public Sprite RockSp;
    public Sprite ScissorsSp;
}
