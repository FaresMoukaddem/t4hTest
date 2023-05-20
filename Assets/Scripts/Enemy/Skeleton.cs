using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public SkeletonMovement skeletonMovement;

    public SkeletonRagdollHandler skeletonRagdollHandler;

    public bool isAlive;

    public int damage = 1;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<PooledObject>().OnTakenOutOfPool.AddListener(OnTakenOutOfPool);

        OnTakenOutOfPool();
    }

    // Update is called once per frame
    void OnTakenOutOfPool()
    {
        isAlive = true;
        skeletonRagdollHandler.ToggleRagdoll(false);
        skeletonMovement.isMoving = true;
    }

    void OnDisable()
    {
        skeletonRagdollHandler.ToggleRagdoll(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void Die()
    {
        if(!isAlive) return;

        GameManager.Instance.AddToScore();

        isAlive = false;
        skeletonMovement.isMoving = false;
        skeletonRagdollHandler.ToggleRagdoll(true);
        GetComponent<BackToPoolTimer>().StartTimer();
    }

    public void Celebrate()
    {
        if(!isAlive) return;

        skeletonMovement.isMoving = false;
        animator.SetTrigger("victory");
    }
}
