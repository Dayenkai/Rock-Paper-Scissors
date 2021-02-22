using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("End");
            Application.Quit();
        }
    }
}
