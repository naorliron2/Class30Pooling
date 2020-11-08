using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    //This is the pool itself, a list of gameobject we can pull from and push to
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    //What object we're going to pool
    [SerializeField] GameObject adamPrefab;
    //Where we sent the object when its in the pool
    [SerializeField] Transform trash;
    //How many objects we want in our pool
    [SerializeField] int poolSize;
    [SerializeField] bool randomizeSize;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize the pool
        InitiatePool();
    }
    //this method is responsible for Initializing the pool, so we instantiate all our objects once at the start
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
            //this will be specific for each object, here we get the script on the object, in this instace the obstacle sctipt, and call the Bind function
            //got to the Obstacle script to see the exolanation to bind
            instance.GetComponent<Obstacle>().Bind(this);

        }
    }
    //this method lets us pull an object from the pool, and set it to the position and rotation that we get from the parameters
    public GameObject PullFromPool(Vector3 position, Quaternion rotation)
    {
        //we make a variable that hold the gameobject in the first container of the list
        GameObject instance = pool[0];
        //we then remove it from the list, but we can still interact with it because we have the variable we created
        pool.Remove(instance);
        //we then set the parent to false, since it was the trash's child before
        instance.transform.parent = null;
        //and then set its position and rotation to the ones we were passed in the parameter
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        if(randomizeSize)
            instance.transform.localScale = new Vector3(1, Random.Range(1, 5), Random.Range(1, 10));
        //activate the object
        instance.SetActive(true);
        
        //here we return the object, this means we can capture it in a variable in the script we pull from
        return instance;
    }
    //in this method we return the object that we get in the parameter to the pool
    public void ReturnToPool(GameObject objectToReturn)
    {
        //we first deactivate the object
        objectToReturn.SetActive(false);
        //then we set its position to the trash's position
        objectToReturn.transform.position = trash.position;
        //set the trash as its parent
        objectToReturn.transform.SetParent(trash);
        //and add it back to the pool
        pool.Add(objectToReturn);

    }

}
