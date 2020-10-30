using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifetime;
    public Pooling myPool;
    [SerializeField]bool noPool;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Shoot()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if (!noPool)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                if (myPool != null)
                    myPool.ReturnToPool(gameObject);
                else{ Destroy(this); }
            }
        }
    }
    public void Bind(Pooling pool)
    {
        myPool = pool;
    }
}
