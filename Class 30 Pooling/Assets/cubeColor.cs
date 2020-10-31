using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeColor : MonoBehaviour
{
    [SerializeField]Material mymat;
    [SerializeField] Pooling myPool;
    [SerializeField] float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
      // mymat.color =new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f));     
    }
    public void Bind(Pooling pool)
    {
        myPool = pool;
    }
    public void ResetCube()
    {
        lifetime = 3;
    }
    // Update is called once per frame
    void Update()
    {
        ControlTimer();
    }

    private void ControlTimer()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            if (myPool != null)
                myPool.ReturnToPool(gameObject);
            else { Destroy(this.gameObject); }
        }
    }
}
