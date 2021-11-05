using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyoutofbounds : MonoBehaviour
{
    public float topBound = 7.5f;
    public float rightBound = 13.8f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.y < -topBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -rightBound)
        {
            Destroy(gameObject);
        }
    }
}
