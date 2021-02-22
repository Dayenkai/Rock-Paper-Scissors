using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI textmesh;
    float timeLeft = 60.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        textmesh.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Duel");
        }
    }
}
