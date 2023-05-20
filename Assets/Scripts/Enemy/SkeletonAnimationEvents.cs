using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationEvents : MonoBehaviour
{
    private City city;

    private Skeleton skeleton;

    public void Start()
    {
        city = City.Instance;
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void Attack()
    {
        if(city != null)
        {
            city.AttackCity(skeleton.damage);
        }
    }
}
