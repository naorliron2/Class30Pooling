using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    //This is the pool itself, a list of gameobject we can pull from and push to
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    //What object we're going to pool
    [SerializeField] GameObject adamPrefab;
    //Where we sent the object when its in the pool
    [SerializeField] Transform trash;
    //How many objects we want in our pool
    [SerializeField] int poolSize;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the pool
        InitiatePool();
    }
    private void InitiatePool()
    {
        //We loop the amount of objects we want in the pool
        for (int i = 0; i < poolSize; i++)
        {
            //each loop we instantiate the prefab, with the trash as its parent
            GameObject instance = Instantiate(adamPrefab, trash);
            //we deactivate the object so we dont see it and the scripts on it dont run
            instance.SetActive(false);
            //add it to the pool, .add() is a list method that lets you grow the list by one and add an object to it
            pool.Add(instance);
            //this will be specific for each object, but here we bind the 
            instance.GetComponent<cubeColor>().Bind(this);

        }
    }
    public GameObject PullFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject instance = pool[0];
        pool.Remove(instance);
        instance.transform.parent = null;
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.SetActive(true);
        instance.GetComponent<cubeColor>().ResetCube();

        return instance;
    }
    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objectToReturn.transform.position = trash.position;
        objectToReturn.transform.SetParent(trash);

        pool.Add(objectToReturn);

    }
}
