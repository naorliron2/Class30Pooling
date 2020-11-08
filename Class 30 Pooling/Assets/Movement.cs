using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    //the speed for moving between lanes
    [SerializeField] float sideSpeed;
    //the speed we move forwards 
    [SerializeField] float forwardSpeed;
    [Header("Debug Info")]
    //the transform components of our lanes, should be in order from left to right
    [SerializeField] Transform[] lanes;
    //the lane we are currently on
    [SerializeField] int currLane;

    // Update is called once per frame
    void Update()
    {
        LaneMovement();
        MoveForward();
    }
    //This method moves us between lanes when we press on the apropriate inputs
    private void LaneMovement()
    {
        //if we press on D, add one to the current lane, so our current lane moves one right
        if (Input.GetKeyDown(KeyCode.D))
        {
            currLane++;
        }
        //if we press on A, subtract one from the current lane, so our current lane moves one lefts

        if (Input.GetKeyDown(KeyCode.A))
        {
            currLane--;
        }
        //we then clamp our lanes between 0 and the amount of lanes we have(-1 because collectios start at 0)
        currLane = Mathf.Clamp(currLane, 0, lanes.Length - 1);
        //we the lerp from out current position to a new vector3, built from the x of our current lane, the players y, and the players z
        transform.position = Vector3.Lerp(transform.position, new Vector3(lanes[currLane].position.x, transform.position.y, transform.position.z), sideSpeed * Time.deltaTime);

    }
    //this method just moves us forward
    private void MoveForward()
    {
        
        transform.Translate(transform.forward * forwardSpeed);
    }

    //if you want very basic free movement, you can replcae move forward with this and comment out lanesmovement
    private void FreeMovement()
    {
        //get out horizontal axis(-1 on when inputting left and 1 when inputiing right
        float horiz = Input.GetAxis("Horizontal");
        //we then move build a vector to move on, on out z axis we just move at our forward speed,
        //and on the x axis we move at the same speed but we multiply by our horizontal axis so we can move both left and right
        transform.Translate(transform.forward * forwardSpeed + transform.right * horiz * forwardSpeed);
    }
}
