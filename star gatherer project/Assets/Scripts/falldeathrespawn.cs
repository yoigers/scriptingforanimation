using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldeathrespawn : MonoBehaviour
{
    public float topBound = 11.33f;

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -topBound)
       {
           Destroy(gameObject);
           print("You fell into a very deep crater.");
       } 
    }
}
