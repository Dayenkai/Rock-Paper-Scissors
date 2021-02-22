using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Canvas canvas;

    public void ManageCanvas(bool active)
    {
        canvas.GetComponent<Canvas>().enabled = active;
    }

}
