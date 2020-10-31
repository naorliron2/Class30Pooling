using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] ObstaclePooler pool;
    [SerializeField] float timeBetweenObstacles;
    [SerializeField] Transform[] lanes;
    [SerializeField] Transform player;
    [SerializeField] float zOffsetFromPlayer;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenObstacles;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeBetweenObstacles;
            pool.PullFromPool(new Vector3(lanes[Random.Range(0,3)].position.x,player.position.y,player.position.z + zOffsetFromPlayer),Quaternion.identity);
        }
    }
}
