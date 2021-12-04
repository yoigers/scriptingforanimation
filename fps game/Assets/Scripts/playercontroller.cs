using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Movement speed in unitspersecond, force applied upwards
    public float moveSpeed;
    public float jumpforce;

    // Mouse-look sensitivity, limited up-down vision, current x rotation on camera
    public float lookSensitivity;
    public float maxLookX = -41f;
    public float minLookX = 34f;
    private float rotX;

    private Camera camera;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        camera = camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }


    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
    }
}
