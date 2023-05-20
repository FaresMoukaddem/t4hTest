using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    public float maxXOffset;

    public Vector2 timesBetweenSpawns;

    public Pooler pooler;

    private Coroutine spawner;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleSpawner(bool on)
    {
        if((on && isOn) || (!on && !isOn)) return;

        if(on)
        {
            spawner = StartCoroutine(SpawnerCoroutine());
            isOn = true;
        }
        else
        {
            StopCoroutine(spawner);
            isOn = false;
        }
    }

    IEnumerator SpawnerCoroutine()
    {
        while(true)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-maxXOffset, maxXOffset);

            pooler.Pool(0, pos, transform.rotation, transform, false);

            yield return new WaitForSeconds(Random.Range(timesBetweenSpawns.x, timesBetweenSpawns.y));
        }
    }

    public void KillAllSkeletons()
    {
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Skeleton>() != null)
            {
                child.GetComponent<Skeleton>().Die();
            }
        }
    }

    public void StopSpawnerAndKillAll()
    {
        ToggleSpawner(false);
        KillAllSkeletons();
    }

    public void MakeEnemiesCelebrate()
    {
        StartCoroutine(CelebrateCoroutine());
    }

    private IEnumerator CelebrateCoroutine()
    {
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Skeleton>() != null)
            {
                child.GetComponent<Skeleton>().Celebrate();
            }

            // Randomize times they celebrate, so it looks more organic.
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
