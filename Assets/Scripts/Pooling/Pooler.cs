using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject prefabToPool;
    public int poolCount;
    private int nextIndexToPool = -1;

    public int GetNextIndexToPool()
    {
        nextIndexToPool++;
        
        if(nextIndexToPool >= poolCount)
        {
            nextIndexToPool = 0;
        }

        return nextIndexToPool;
    }
}

public class Pooler : Singleton<Pooler>
{
    public Pool[] pools;

    // Start is called before the first frame update
    void Awake()
    {
        base.Awake();

        GameObject prefabRef;
        for(int i = 0; i < pools.Length; i++)
        {
            GameObject child = new GameObject(i.ToString());
            child.transform.SetParent(transform);

            for(int j = 0; j < pools[i].poolCount; j++)
            {
                prefabRef = Instantiate(pools[i].prefabToPool, transform.position, Quaternion.identity, child.transform);
                
                if(prefabRef.GetComponent<PooledObject>() != null)
                {
                    prefabRef.GetComponent<PooledObject>().SetPool(child.transform);
                }

                prefabRef.SetActive(false);
            }
        }
    }

    public GameObject Pool(int poolIndex, Vector3 position, Quaternion rotation, Transform newParent = null, bool increaseSizeIfNeeded = true)
    {
        if(transform.GetChild(poolIndex).childCount == 0)
        {
            Debug.LogWarning("The pool " + poolIndex + " has no available objects at this moment, increasing pool size.");

            if(increaseSizeIfNeeded)
            {
                IncreasePoolSize(poolIndex);
            }
            else
            {
                return null;
            }
        }

        GameObject pooledObject = transform.GetChild(poolIndex).GetChild(0).gameObject;

        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        pooledObject.transform.localScale = Vector3.one;

        pooledObject.transform.SetParent(newParent);

        pooledObject.SetActive(true);

        if(pooledObject.GetComponent<PooledObject>() != null)
        {
            pooledObject.GetComponent<PooledObject>().OnTakenOutOfPool?.Invoke();
        }
        else
        {
            Debug.LogError("THIS POOLED OBJECT DOES NOT HAVE THE POOLED OBJECT COMPONENT!");
        }

        return pooledObject;
    }

    private void IncreasePoolSize(int poolIndex, int amountToIncrease = 5)
    {
        GameObject prefabRef;

        for(int i = 0; i < amountToIncrease; i ++)
        {
            prefabRef = Instantiate(pools[poolIndex].prefabToPool, transform.position, Quaternion.identity, transform.GetChild(poolIndex));
                    
            if(prefabRef.GetComponent<PooledObject>() != null)
            {
                prefabRef.GetComponent<PooledObject>().SetPool(transform.GetChild(poolIndex));
            }

            prefabRef.SetActive(false);
        }
    }
}
