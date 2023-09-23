using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TMP_Text timerText;
    public string timer;
    public bool timesIUp = false;


    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    void Update()
    {
        //Timer
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))) 
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            timesIUp = true;
        }


        SetTimerText();
      

    }

    private void SetTimerText() {

        timer = currentTime.ToString("0.00");
        timerText.text = "Time: " + timer;

    }

}
