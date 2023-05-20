using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericPopup : MonoBehaviour
{
    public ImageAlphaLerper fadedBackgroundLerper;

    public ScaleLerpWGraph popupLerper;

    public GameObject childrenObject;

    private bool isToggled;

    public void Awake()
    {
        childrenObject.SetActive(false);
        isToggled = false;
    }

    void Start()
    {
    }

    public void ShowPopup(Action callback = null)
    {
        if(isToggled) return;

        isToggled = true;

        childrenObject.gameObject.SetActive(true);

        fadedBackgroundLerper.StartLerping(0,0.5f);
        popupLerper.StartLerping(Vector3.zero, Vector3.one, (g) => 
        {
            callback?.Invoke();
        });
    }

    public void HidePopup(Action callback = null)
    {
        if(!isToggled) return;

        isToggled = false;

        fadedBackgroundLerper.StartLerping(0.5f,0);
        popupLerper.StartLerping(Vector3.one, Vector3.zero, (g) => 
        {
            childrenObject.gameObject.SetActive(false);
            callback?.Invoke();
        });
    }

    private bool GetIsToggled()
    {
        return isToggled;
    }
}
