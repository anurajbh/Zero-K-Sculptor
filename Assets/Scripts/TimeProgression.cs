using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeProgression : MonoBehaviour
{
    public float timeToEnd = 300f;
    public float timer = 0f;
    // Update is called once per frame
    public static TimeProgression Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        InvokeRepeating("IncrementTimer", 1f, 1f);
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
        return param;
    }
    private void EndGame()
    {
        Destroy(gameObject);//bring player back to main menu
    }
}
