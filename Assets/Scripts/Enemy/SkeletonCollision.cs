using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCollision : MonoBehaviour
{
    public SkeletonMovement skeletonMovement;

    public int pyramidColliderLayer;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == pyramidColliderLayer)
        {
            skeletonMovement.StopMovement();
            anim.SetTrigger("attack");
        }
    }
}
