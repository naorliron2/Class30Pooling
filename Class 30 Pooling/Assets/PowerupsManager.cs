using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PowerupsManager : MonoBehaviour
{

    [SerializeField] CoinPooler goldenCircle;

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
            timer = timeBetweenObstacles;
           

            goldenCircle.PullFromPool(new Vector3(lanes[randLane].position.x, player.position.y, player.position.z + zOffsetFromPlayer), Quaternion.identity);

        }
    }
}
