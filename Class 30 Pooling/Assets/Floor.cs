using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    //A reference to the ground manager that does the actual spawning
    public GroundManager groundManagerScript;
    //the pool this object comes from
    public FloorPooling pool;
    //how much time it takes to return to the pool after the timer starts
    [SerializeField] float returnToPoolTime;
    //the timer we countdow on
    [SerializeField] float timer;
    // if this is false, we dont start counting yet
    [SerializeField] bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        //at the start, find the ground manager
        groundManagerScript = FindObjectOfType<GroundManager>();
        //set the timer
        timer = returnToPoolTime;
    }
    private void Update()
    {
        ControlTimer();
    }
    //this method counts down our timer and when it reeaches zero, returns to the pool
    private void ControlTimer()
    {
        //if we started the timer
        if (startTimer)
        {
            //Time.deltaTime is the time in between this and the last frame, adding or subtracting Time.deltaTime from a variale subtracts or adds 1 from it every second
            timer -= Time.deltaTime;
            //if the timer is <= 0 than the apropriate amount of time has past
            if (timer <= 0)
            {
                //we then reset the obstacle before returning it to the pool
                ResetFloor();
                //and we retun the object, "gameobject" is the gameobject this script is on, or our instance 
                pool.ReturnToPool(this.gameObject);
            }
        }
    }
    //since we recycle objects, we will probably need to reset our object so its like a new object
    public void ResetFloor()
    {
        startTimer = false;
        timer = returnToPoolTime;
    }
    //on trigger enter gets called whenever something touches the collider
    private void OnTriggerEnter(Collider other)
    {
        //we then check if its a player
        if (other.CompareTag("Player"))
        {
            //if it is, we activate the spawngeound method in GroundManager, and we pass in the current floors position
            groundManagerScript.spawnGround(transform.position);
            //we start the timer, since this means we passed the middle of the floor and we can start the timer to destroy it
            startTimer = true;
        }
        
    }
}
