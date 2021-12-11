using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymeteors : MonoBehaviour
{
    public int damage;
    public float fallTime;
    
    public GameObject fallParticle;

    private GameObject target;
    private GameObject meteor;

    void OnEnable()
    {
        fallTime = Time.time;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<playercontroller>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<playercontroller>().gameObject;
    }


    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
