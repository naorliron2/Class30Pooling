using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPoolingGun : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform gunTip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(prefab,transform.position,Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shoot();

        }
    }
}
