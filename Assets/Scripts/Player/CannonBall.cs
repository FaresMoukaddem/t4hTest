using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Rigidbody rb;

    public float force;

    public float explosionForce;

    public float radius;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(rb == null) rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 7 || other.gameObject.layer == 8)
        {
            Explode();
            GetComponent<PooledObject>().ReturnToPool();
        }
    }

    void Explode()
    {
        Pooler.Instance.Pool(2, transform.position, Quaternion.identity);

        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, 1 << 8);
        
        foreach(Collider collider in enemies)
        {
            collider.GetComponent<Skeleton>().Die();
            collider.GetComponent<Rigidbody>().AddForce((collider.transform.position - transform.position).normalized * explosionForce, ForceMode.Impulse);
        }
    }
}
