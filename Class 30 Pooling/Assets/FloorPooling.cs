using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPooling : MonoBehaviour
{
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    [SerializeField] GameObject adamPrefab;
    [SerializeField] Transform trash;
    [SerializeField] int poolSize;
    // Start is called before the first frame update
    void Start()
    {
        InitiatePool();
    }
    private void InitiatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(adamPrefab, trash);
            instance.SetActive(false);
            pool.Add(instance);
            Floor floorScript = instance.GetComponent<Floor>();
            floorScript.pool = this;
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
