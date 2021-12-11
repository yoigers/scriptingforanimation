using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienweapon : MonoBehaviour
{
    public objectpool meteorPool;
    public Transform ship;

    public bool infiniteAmmo;

    public float meteorSpeed, shootRate;

    private float lastShootTime;
    private bool isPlayer;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<playercontroller>())
        {
            isPlayer = true;
        }
    }


    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(infiniteAmmo == true)
            {
                return true;
            }
        }

        return false;
    }


    public void Shoot()
    {
        lastShootTime = Time.time;

        GameObject meteor = meteorPool.GetObject();

        meteor.transform.position = ship.position;
        meteor.transform.rotation = ship.rotation;

        meteor.GetComponent<Rigidbody2D>().velocity = ship.forward * meteorSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
