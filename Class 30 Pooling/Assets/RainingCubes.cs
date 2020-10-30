using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingCubes : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Collider col;
    [SerializeField] bool Pooling;
    [SerializeField] Pooling CubePool;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeBetweenSpawns;
            if(!Pooling)
                for (int i = 0; i < 20; i++)
                {
                    Instantiate(prefab, new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), transform.position.y - 2, Random.Range(-transform.localScale.z, transform.localScale.z)), Quaternion.identity);
                }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    CubePool.PullFromPool(new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), transform.position.y - 2, Random.Range(-transform.localScale.z, transform.localScale.z)), Quaternion.identity);
                }
            }
        }
    }
}
