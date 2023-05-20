using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaLerper : GenericLerper<float>
{
    public Image image;

    private Color tempColor;

    public override void Lerp(float fromVal, float toVal, float t)
    {
        SetImageAlpha(Mathf.Lerp(fromVal, toVal, t));
    }

    private void SetImageAlpha(float val)
    {
        tempColor = image.color;
        tempColor.a = val;
        image.color = tempColor;
    }
}
