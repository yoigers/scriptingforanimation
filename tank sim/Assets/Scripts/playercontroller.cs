using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float speed = 10.5f;
    public float turnSpeed;

    public float hInput;
    public float vInput;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Moves the tank left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
        // Moves the tank forward and back
       transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput); 
    }
}
