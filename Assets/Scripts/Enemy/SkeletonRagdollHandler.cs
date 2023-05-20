using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRagdollHandler : MonoBehaviour
{
    public Transform rigRoot;
    public Rigidbody mainRb;
    public Collider mainCollider;
    public Animator animator;
    public Rigidbody[] rigidbodies;
    public Collider[] colliders;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodies = rigRoot.GetComponentsInChildren<Rigidbody>();
        colliders = rigRoot.GetComponentsInChildren<Collider>();
    }

    public void ToggleRagdoll(bool on)
    {
        //mainRb.isKinematic = on;
        animator.enabled = !on;
        //mainCollider.enabled = !on;

        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = !on;
        }

        foreach(Collider collider in colliders)
        {
            collider.enabled = on;
        }
    }
}
