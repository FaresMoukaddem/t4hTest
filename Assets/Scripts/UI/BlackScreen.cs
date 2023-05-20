using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BlackScreen : MonoBehaviour
{
    public ImageAlphaLerper imageAlphaLerper;

    public Image image;

    public bool isToggledOnStart;

    private bool isToggled;

    private Color onColorValue, offColorValue;

    // Start is called before the first frame update
    void Awake()
    {
        onColorValue = image.color;
        onColorValue.a = 1;

        offColorValue = onColorValue;
        offColorValue.a = 0;

        SetIsToggled(isToggledOnStart);
    }

    public void LerpScreenIn(Action callback = null)
    {
        if(isToggled) return;

        isToggled = true;

        image.gameObject.SetActive(true);
        imageAlphaLerper.StartLerping(0, 1, (g) => 
        {
            callback?.Invoke();
        });
    }

    public void LerpScreenOut(Action callback = null)
    {
        if(!isToggled) return;

        isToggled = false;

        imageAlphaLerper.StartLerping(1, 0, (g) => 
        {
            image.gameObject.SetActive(false);
            callback?.Invoke();
        });
    }

    private bool GetIsToggled()
    {
        return isToggled;
    }

    public void SetIsToggled(bool on)
    {
        isToggled = on;

        image.color = on ? onColorValue : offColorValue;
    
        image.gameObject.SetActive(on);
    }
}
