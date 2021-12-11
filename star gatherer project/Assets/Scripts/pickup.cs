using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    public GameObject shineParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public enum PickupType
    {
        Star
    }

    // Stars picked up
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playercontroller player = other.GetComponent<playercontroller>();
            
            switch(type)
            {
                case PickupType.Star:
                player.GiveScore(value);
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

    }
}
