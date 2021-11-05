using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 100.0f;
    public float hInput;
    public float vInput;

    public float xRange = 12.87f;
    public float yRange = 6.73f;

    public GameObject projectile;
    public Transform launcher;


    //public float health

    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");

       transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
       transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
    // Create a wall on the -x side
       if(transform.position.x < -xRange)
       {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
       }
    // Create a wall on x side
       if(transform.position.x > xRange)
       {
           transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
       }
    // Create a wall on -y side
       if(transform.position.y < -yRange)
       {
           transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
       }
    // Create a wall on y side
       if(transform.position.y > yRange)
       {
           transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
       }   

       if(Input.GetKeyDown(KeyCode.Space))
       {
           Instantiate(projectile, launcher.transform.position, projectile.transform.rotation);
       }
    }
}
