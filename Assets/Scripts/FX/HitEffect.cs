using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public MaterialColorLerper materialColorLerper;

    public Color color;

    // Start is called before the first frame update
    public void PlayEffect()
    {
        materialColorLerper.StartLerping(Color.white, color, (g) => 
        {
            materialColorLerper.StartLerping(color, Color.white);
        });
    }
}
