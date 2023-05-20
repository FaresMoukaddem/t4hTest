using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberTextLerper : GenericLerper<float>
{
    public TMPro.TMP_Text text;

    public override void Lerp(float fromVal, float toVal, float t)
    {
        text.text = ((int)Mathf.Lerp(fromVal,toVal,t)).ToString();
    }

    public void SetTextValue(int value)
    {
        text.text = value.ToString();
    }
}
