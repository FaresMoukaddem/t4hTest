using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class GenericLerper<T> : MonoBehaviour
{
    public float speed;

    protected T fromVal;

    protected T toVal;

    private float t;
    private bool isLerping;

    private Action<GameObject> OnFinishedLerpAction;

    private float usedSpeed;

    // Update is called once per frame
    void Update()
    {
        if(isLerping)
        {
            t += Time.deltaTime * usedSpeed;

            Lerp(fromVal, toVal, t);

            if(t >= 1)
            {
                isLerping = false;

                OnFinishedLerpAction?.Invoke(gameObject);
                OnFinishedLerpAction = null;
            }
        }
    }

    public void StartLerping(T fromVal, T toVal, Action<GameObject> OnFinishedLerpAction = null, float speedToUse = 0)
    {
        t = 0;

        usedSpeed = speedToUse > 0 ? speedToUse : speed;

        this.fromVal = fromVal;
        this.toVal = toVal;

        this.OnFinishedLerpAction = OnFinishedLerpAction;

        isLerping = true;
    }

    // Turn off the lerp on disable,
    // so it doesn't resume after being turned on.
    public void OnDisable()
    {
        t = 0;
        isLerping = false;
    }

    public abstract void Lerp(T fromVal, T toVal, float t);
}
