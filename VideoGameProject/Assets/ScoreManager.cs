using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ui;
    public static int scorevalue = 0;
    [SerializeField] private GameObject VictoryScreen;
    float timeScaleBeforePause = 1f;
    // Update is called once per frame
    void Update()
    {
        if (scorevalue < 150)
        {
            string scoreMessage = "Score: " + scorevalue.ToString();
            ui.text = scoreMessage;
        }
        else
        {
            Victory();
        }

        void Victory() 
        {
            VictoryScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0f;
        }

    }
}
