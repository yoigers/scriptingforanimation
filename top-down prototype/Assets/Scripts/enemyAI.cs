using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }





    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
    
}
