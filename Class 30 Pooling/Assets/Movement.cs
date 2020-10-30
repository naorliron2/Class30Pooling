using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float sideSpeed;
    [SerializeField] float forwardSpeed;
    [Header("Debug Info")]
    [SerializeField] Transform[] lanes;
    [SerializeField] int currLane;
    [SerializeField] float horiz;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        LaneMovement();
        MoveForward();
    }

    private void LaneMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currLane++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currLane--;
        }
        currLane = Mathf.Clamp(currLane, 0, lanes.Length - 1);

        if(lanes[currLane]!= null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(lanes[currLane].position.x,transform.position.y, transform.position.z), sideSpeed * Time.deltaTime);
        }
    }

    private void MoveForward()
    {
        transform.Translate(transform.forward * forwardSpeed);
    }
}
