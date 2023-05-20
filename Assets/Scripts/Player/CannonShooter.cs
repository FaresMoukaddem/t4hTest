using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public CannonControls cannonControls;

    public Pooler pooler;

    public Transform muzzle;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        cannonControls.OnCannonShoot.AddListener(Shoot);
    }

    // Update is called once per frame
    void Shoot()
    {
        pooler.Pool(1, muzzle.position, muzzle.rotation);
        animator.SetTrigger("shoot");
    }
}
