using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] FloorPooling floorPool;
    [SerializeField] float groundOffset;
    // Start is called before the first frame update
   
    public void spawnGround(Vector3 floorPos)
    {
        Debug.Log("Spawned!");
        GameObject instance = floorPool.PullFromPool(floorPos + new Vector3(0, 0, groundOffset),Quaternion.identity);
        instance.GetComponent<Floor>().groundManagerScript = this;
    }
}
