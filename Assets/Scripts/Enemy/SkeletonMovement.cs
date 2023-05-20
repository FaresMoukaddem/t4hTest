using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public Animator anim;

    public Rigidbody rb;

    public float speed, movementAnimationMultiplier = 1.0f;

    public bool isMoving;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            SetMotionForward();

            anim.SetFloat("WalkBlend", rb.velocity.magnitude * movementAnimationMultiplier);
        }
    }

    void SetMotionForward()
    {
        rb.velocity = new Vector3(0,0, speed);
    }

    public void StopMovement()
    {
        isMoving = false;
        rb.velocity = Vector3.zero;
    }
}
