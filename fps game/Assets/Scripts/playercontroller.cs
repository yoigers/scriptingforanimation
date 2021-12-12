using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [Header("Stats")]
    // Movement speed in unitspersecond, force applied upwards
    public float moveSpeed;
    public float jumpForce;

    public int curHp;
    public int maxHp;
    
    [Header("Mouse Look")]
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

        // Initialize the UI
        gameUI.instance.UpdateHealthBar(curHp, maxHp);
        gameUI.instance.UpdateScoreText(0);
        gameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

    // Applies damage to player
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
        {
            Die();
        }

        gameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    // If player's health is 0 or less, they die
    void Die()
    {
        gamemanager.instance.LoseGame();
    }

    // Move around, move where camera goes
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // rb.velocity = new Vector3(x, rb.velocity.y, z); --this is old code
        // Move direction relative to the camera
        Vector3 dir = transform.right * x + transform.forward * z;

        dir.y = rb.velocity.y;
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

        // Add force to jump
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Player picks up and receives health points
    public void GiveHealth(int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        gameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    // Player picks up and receives ammo
    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        gameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
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

        if(Input.GetKeyDown("space"))
        {
            Jump();
        }

        // Game freezes while pause is in effect
        if(gamemanager.instance.gamePaused == true)
        {
            return;
        }
    }
}
