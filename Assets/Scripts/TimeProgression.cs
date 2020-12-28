using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeProgression : MonoBehaviour
{
    public float timeToEnd = 300f;
    public float timeLeft;
    public float timer = 0f;
    public Image defeatPanel;
    public Text timerText;
    private void Awake()
    {
        timeLeft = Mathf.Clamp(timeToEnd / 100f, 0f, 300f);
        timerText.text = "Temp : " + timeLeft.ToString() + " K";
        InvokeRepeating("DecrementTimer", 1f, 1f);
        InvokeRepeating("IncrementTimer", 1f, 1f);

    }
    void DecrementTimer()
    {
        timeLeft = (float)Math.Round(timeLeft -0.01f,2);
        if(timeLeft<0f)
        {
            timeLeft = 0f;
        }
        timerText.text = "Temp : " + timeLeft.ToString() + " K";
    }
    void Update()
    {
        if (timer > timeToEnd)
        {
            EndGame();
        }
    }

    private void IncrementTimer()
    {
        timer += 1f;
    }

    public float SlowDownGame(float param, float maxParam)
    {
        param -= (1.0f / timeToEnd) * maxParam;
        if(param<0f)
        {
            param = 0f;
        }
        return param;
    }
    private void EndGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        defeatPanel.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
