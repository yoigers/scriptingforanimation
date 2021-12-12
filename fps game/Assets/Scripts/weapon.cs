using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    //public GameObject bulletPrefab; --this is old code replaced with ObjectPool
    public objectpool bulletPool;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;

    private float lastShootTime;
    private bool isPlayer;

    // 
    void Awake()
    {
        // Disable cursor
        Cursor.lockState = CursorLockMode.Locked;

        if(GetComponent<playercontroller>())
        {
            isPlayer = true;
        }
    }

    // You can only shoot after a short cool-down period and you have ammo
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }

        return false;
    }

    // 
    public void Shoot()
    {
        // Cooldown
        lastShootTime = Time.time;
        curAmmo--;
        
        // Creating an instance of the bullet prefab at muzzle's position and rotation
        //GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); --this is old code, replaced by bulletPool below
        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // Add velocity to projectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    
        if(isPlayer)
        {
            gameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
        }
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
