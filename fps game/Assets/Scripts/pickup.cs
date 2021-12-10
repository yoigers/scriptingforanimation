using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private bool bobbingUp;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }


    public enum PickupType
    {
        Health,

        Ammo
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playercontroller player = other.GetComponent<playercontroller>();
            
            switch(type)
            {
                case PickupType.Health:
                player.GiveHealth(value);
                break;

                case PickupType.Ammo:
                player.GiveAmmo(value);
                break;

                default:
                print("Type not accepted");
                break;
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate pickup around y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0));
    
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);
    
        if(transform.position == startPos + offset)
        {
            bobbingUp = !bobbingUp;
        }
    }
}
