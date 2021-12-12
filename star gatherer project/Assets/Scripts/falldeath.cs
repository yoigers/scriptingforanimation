using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldeath : MonoBehaviour
{
    public float topBound = 11.33f;

    private AudioSource dieSound;

    // Start is being called before game starts or w/e
    void Start()
    {
        dieSound = GetComponent<AudioSource>();
    }
   
    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -topBound)
       {
           print("You fell into a very deep crater.");
           dieSound.Play();
       } 
      
    }
}
