using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float timeToReturnToPool;
    public ObstaclePooler pool;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToReturnToPool; 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ResetObstacle();
            pool.ReturnToPool(this.gameObject);
        }
    }
    public void Bind(ObstaclePooler toBind)
    {
        pool = toBind;
    }
    public void ResetObstacle()
    {
        timer = timeToReturnToPool;
    }
}
