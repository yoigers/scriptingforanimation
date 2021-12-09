using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Movement speed in unitspersecond, force applied upwards
    public float moveSpeed;
    public float jumpForce;

    // Mouse-look sensitivity, limited up-down vision, current x rotation on camera
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;

    private Camera camera;
    private Rigidbody rb;
    private weapon weapon;


    void Awake()
    {
        weapon = GetComponent<weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        
        if(Input.GetKeyDown("e"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }


    void FixedUpdate()
    {
        if(Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    // Move around, move where camera goes
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x, rb.velocity.y, z); --this is old code
        Vector3 dir = transform.right * x + transform.forward * z;
        rb.velocity = dir;
    }

    // Use mouse to look around
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    // Player can jump
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
