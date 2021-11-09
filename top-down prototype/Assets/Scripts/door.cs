using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public gamemanager gameManager;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && gameManager.hasKey == true)
        {
            print("You used the key to unlock the door!");
            gameManager.isDoorLocked = false;
        }
        else
        {
            print("The door is locked. You are unable to leave.");
        }
    }
}
