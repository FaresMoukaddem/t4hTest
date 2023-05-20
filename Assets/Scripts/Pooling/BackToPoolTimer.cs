using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPoolTimer : MonoBehaviour
{
    public bool startOnEnable;

    public float time;

    private float t;

    private bool timerIsOn;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(startOnEnable)
        {
            StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsOn)
        {
            if(t <= time)
            {
                t += Time.deltaTime;
            }
            else
            {
                timerIsOn = false;
                GetComponent<PooledObject>().ReturnToPool();
            }
        }
    }

    public void StartTimer()
    {
        timerIsOn = true;
        t = 0;
    }
}