using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class enemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;

    private Rigidbody2D rb;

    private Vector2 movement;

    private alienweapon ship;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ship = GetComponent<alienweapon>();
    }


    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            print("You were crushed by an alien ship.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }


    void FixedUpdate()
    {
        MoveEnemy(movement);
    }
}
