using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;

    public float lerpSpeed;

    public Color highColor, midColor, lowColor;

    public Image image;

    private int currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, currentTarget, lerpSpeed * Time.deltaTime);
    }

    public void SetMaxHealth(int amount)
    {
        slider.maxValue = amount;
    }

    public void SetCurrentTarget(int amount)
    {
        currentTarget = amount;
        ColorBar();
    }

    public void SetValue(int amount)
    {
        currentTarget = amount;
        slider.value = currentTarget;
        ColorBar();
    }

    private void ColorBar()
    {
        if(slider.value >= slider.maxValue * 0.6f)
        {
            image.color = highColor;
        }
        else if(slider.value >= slider.maxValue * 0.3f)
        {
            image.color = midColor;
        }
        else
        {
            image.color = lowColor;
        }
    }
}
