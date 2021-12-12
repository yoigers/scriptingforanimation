using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorshots : MonoBehaviour
{
    public int damage;
    public float lifetime;
    public float shootTime;
    
    public GameObject hitParticle;

    private GameObject target;
    private GameObject meteor;

    void OnEnable()
    {
        shootTime = Time.time;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<playercontroller>().TakeDamage(damage);
        }

        gameObject.SetActive(false);

        // Hit particle
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<playercontroller>().gameObject;
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
