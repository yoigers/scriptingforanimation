using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 10f;
    public float hInput;
    public float vInput;

    public float xRange = 17.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
        transform.Translate(Vector2.right * speed * hInput * Time.deltaTime);

    // Create walls on left and right
        if(transform.position.x < -xRange)
           {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
           }
        if(transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
    }
}
