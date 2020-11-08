using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    [SerializeField] ObstaclePooler cubePool;
    [SerializeField] ObstaclePooler circleCube;
    [SerializeField] ObstaclePooler cylinderPool;
    [SerializeField] ObstaclePooler goldenCircle;

    [SerializeField] float timeBetweenObstacles;
    [SerializeField] Transform[] lanes;
    [SerializeField] Transform player;
    [SerializeField] float zOffsetFromPlayer;
    [SerializeField] float timer;
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
            int randLane = Random.Range(0, 3);
          
            int roll = Random.Range(1, 101);
            if (roll >= 1 && roll <= 30)
            {
                cubePool.PullFromPool(new Vector3(lanes[randLane].position.x, player.position.y, player.position.z + zOffsetFromPlayer), Quaternion.identity);

            }
            else if (roll >= 31 && roll <= 60)
            {
                circleCube.PullFromPool(new Vector3(lanes[randLane].position.x, player.position.y, player.position.z + zOffsetFromPlayer), Quaternion.identity);
            } else if(roll >= 61 && roll <= 90)
            {
                cylinderPool.PullFromPool(new Vector3(lanes[randLane].position.x, player.position.y, player.position.z + zOffsetFromPlayer), Quaternion.identity);
            }else if(roll >= 91 && roll <= 100)
            {
                //goldenCircle.PullFromPool(new Vector3(lanes[randLane].position.x, player.position.y, player.position.z + zOffsetFromPlayer), Quaternion.identity);
            }
            timer = timeBetweenObstacles;
        }
    }
}
