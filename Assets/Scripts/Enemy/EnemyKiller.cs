using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8)
        {
            if(other.gameObject.GetComponent<Skeleton>() != null)
            {
                other.gameObject.GetComponent<Skeleton>().Die();
            }
        }
    }
}
