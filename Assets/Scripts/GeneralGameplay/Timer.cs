using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float seconds;

    public bool isRunning;

    [HideInInspector]
    public UnityEvent OnTimerFinished;

    public TMP_Text timerText;

    // Start is called before the first frame update
    public void StartTimer()
    {
        isRunning = true;

        UpdateTimerText();
    }

    public void SetSeconds(float val)
    {
        if(val < 0) return;

        seconds = val;
    }

    public void AddSeconds(float val)
    {
        seconds += val;
    }

    public void UpdateTimerText()
    {
        if(timerText != null)
        {
            timerText.text = TimeSpan.FromSeconds(seconds).ToString(@"mm\:ss");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            if(seconds > 0)
            {
                seconds -= Time.deltaTime;

                UpdateTimerText();
            }
            else
            {
                isRunning = false;
                OnTimerFinished?.Invoke();
                OnTimerFinished.RemoveAllListeners();
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
