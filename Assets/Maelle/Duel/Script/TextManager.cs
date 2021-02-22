using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public bool end = false;

    public float appear = 2f;
    private float disappear;

    public bool isactive = false;

    public void TextEnable()
    {
        text.gameObject.SetActive(true);
        disappear = Time.time + appear;
        isactive = true;
    }

    void Update()
    {
        Diseaper();
    }

    void Diseaper()
    {
        if (text.gameObject.activeSelf && (Time.time >= disappear))
        {
            text.gameObject.SetActive(false);
            isactive = false;
        }
    }

}
