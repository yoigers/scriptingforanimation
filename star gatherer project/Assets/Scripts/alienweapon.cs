using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienweapon : MonoBehaviour
{
    public GameObject meteor;
    public Transform ship;

    public bool infiniteMeteor;

    public float meteorSpeed, shootRate;

    private float lastShootTime;
    private bool isPlayer;


    void Awake()
    {
        if(GetComponent<playercontroller>())
        {
            isPlayer = true;
        }
    }


    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(infiniteMeteor == true)
            {
                return true;
            }
        }

        return false;
    }


    public void Shoot()
    {
        lastShootTime = Time.time;

        meteor.transform.position = ship.position;
        meteor.transform.rotation = ship.rotation;

        meteor.GetComponent<Rigidbody2D>().velocity = ship.right * meteorSpeed;
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
