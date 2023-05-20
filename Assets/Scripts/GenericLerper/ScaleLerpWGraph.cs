using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleLerpWGraph : GenericLerper<Vector3>
{
    public AnimationCurve curve;
    public override void Lerp(Vector3 fromVal, Vector3 toVal, float t)
    {
        transform.localScale = Vector3.Lerp(fromVal, toVal, curve.Evaluate(t));
    }
}
