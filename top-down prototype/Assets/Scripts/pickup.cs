using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public string pickupName;
    public int amount = 1;

    public gamemanager gameManager;
    
    void Update()
    {
        transform.Rotate(Vector3.back * 75 * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        print("You picked up the golden key!");
        gameManager.hasKey = true;
        Destroy(gameObject);
    }
}
