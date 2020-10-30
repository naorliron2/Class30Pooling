using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GroundManager groundManagerScript;
    public FloorPooling pool;
    [SerializeField] float returnToPoolTime;
    [SerializeField] float timer;
    [SerializeField] bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        groundManagerScript = FindObjectOfType<GroundManager>();
        timer = returnToPoolTime;
    }
    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ResetFloor();
                pool.ReturnToPool(this.gameObject);
            }
        }
    }
    public void ResetFloor()
    {
        startTimer = false;
        timer = returnToPoolTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            groundManagerScript.spawnGround(transform.position);
            startTimer = true;
        }
        
    }
}
