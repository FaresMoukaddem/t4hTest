using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMath : Singleton<GeneralMath>
{
    public float NormalizeValue(float current, float min, float max)
    {
        return (current - min) / (max - min);
    }
}
