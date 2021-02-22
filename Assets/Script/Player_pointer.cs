using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_pointer : MonoBehaviour
{
    public Image fill;
    public Color color;

    private void Start()
    {
        if (color == Color.clear) fill.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        else fill.color = color;
    }

}
