using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorLerper : GenericLerper<Color>
{
    public Renderer renderer;

    private Material mat;

    public override void Lerp(Color fromVal, Color toVal, float t)
    {
        mat.color = Color.Lerp(fromVal, toVal, t);
    }

    // Start is called before the first frame update
    void Awake()
    {
        mat = renderer.material;
    }
}
