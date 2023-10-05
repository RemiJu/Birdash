using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    float timer;
    int reward;
    int salary;
    bool isRunning = false;

    private static TimerManager instance;

    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("TimerManager").AddComponent<TimerManager>();
            }
            return instance;
        }
    }
            
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        RunTimer();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void RunTimer()
    {
        if (isRunning == true)
        {
            timer -= Time.deltaTime;
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void LongDelivery()
    {
        timer = 60f;
        StartTimer();
    }

    public void MediumDelivery()
    {
        timer = 45f;
        StartTimer();
    }

    public void ShortDelivery()
    {
        timer = 30f;
        StartTimer();
    }

    public void BigReward()
    {
        if (timer > 45f)
        {
            reward = 30;
            salary += reward;
        }
    }

    public void MediumReward()
    {
        if (timer > 30f && timer < 45f)
        {
            reward = 20;
            salary += reward;
        }
    }

    public void SmallReward()
    {
        if (timer > 0f && timer < 30f)
        {
            reward = 10;
            salary += reward;
        }
    }

    public void NoReward()
    {
        if (timer < 0f)
        {
            reward = 0;
        }
    }




    
}
