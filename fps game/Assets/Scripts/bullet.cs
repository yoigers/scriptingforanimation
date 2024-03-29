using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject hitParticle;


    void OnEnable()
    {
        shootTime = Time.time;
    }

    // Whoever gets hit - enemy or player - will take damage
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<playercontroller>().TakeDamage(damage);
        }
        else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<enemyAI>().TakeDamage(damage);
        }

        // Disable projectile for future use
        gameObject.SetActive(false);

        // Create the hit particle
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }
}
