using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //how long we need to countdown before we return the object to pool, you are welcome to replace the timer logic but whatever is relevant for an object,
    //for example in a coin you would probably also use a collider to return the object when you hit it
    [SerializeField] float timeToReturnToPool;
    [SerializeField] ScoreManager scoreManager;
    //the pool this object returns to
    public CoinPooler pool;
    //the timer we actually do the countdown on
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //when we start, i set the timer to the amount of time we need to count
        scoreManager = FindObjectOfType<ScoreManager>();
        timer = timeToReturnToPool;
    }

    // Update is called once per frame
    void Update()
    {
        //Ill explain the timer logic in case you ever need to use timers in the future
        //Time.deltaTime is the time in between this and the last frame, adding or subtracting Time.deltaTime from a variale subtracts or adds 1 from it every second
        timer -= Time.deltaTime;
        //if the timer is <= 0 than the apropriate amount of time has past
        if (timer <= 0)
        {
            //we then reset the obstacle before returning it to the pool
            ResetObstacle();
            //and we retun the object, "gameobject" is the gameobject this script is on, or our instance 
            pool.ReturnToPool(gameObject);
        }

    }

    //in this method we bind the pool this object belongs to this object, we get the pool we belong to from the parameter
    public void Bind(CoinPooler toBind)
    {
        //and set the field we have in our class to it
        pool = toBind;
    }
    //since we recycle objects, we will probably need to reset our object so its like a new object
    public void ResetObstacle()
    {
        //since in this object the only thing tht actually changes is the timer, we reset it back to the time it needs to countdown
        timer = timeToReturnToPool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OnTrack"))
        {
            Debug.Log("COL!");
            pool.ReturnToPool(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreManager.AddScore();
            pool.ReturnToPool(this.gameObject);

        }
    }
}
