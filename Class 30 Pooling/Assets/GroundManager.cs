using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    //the floor pool
    [SerializeField] FloorPooling floorPool;
    //How far away we need to spawn the floor on the z axis 
    [SerializeField] float groundOffset;

    //this method pulls the floor from the pool for us, and since it is spublic it can be called from another script if it has a reference to this script
    //it also asks for the floor position of the floor calling the method
    public void spawnGround(Vector3 floorPos)
    {
        Debug.Log("Spawned!");
        //we then pull the floor from the pool, and we put it at the position of the last floor and add an offset to the z
        floorPool.PullFromPool(floorPos + new Vector3(0, 0, groundOffset), Quaternion.identity);
    }
}
