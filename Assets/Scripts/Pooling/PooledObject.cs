using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PooledObject : MonoBehaviour
{
    private Transform pool;

    [HideInInspector]
    public UnityEvent OnTakenOutOfPool;

    [HideInInspector]
    public UnityEvent OnTakenBackToPool;

    public void SetPool(Transform pool)
    {
        this.pool = pool;
    }

    public void ReturnToPool()
    {
        transform.gameObject.SetActive(false);
        transform.SetParent(pool);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
