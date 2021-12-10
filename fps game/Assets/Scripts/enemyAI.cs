using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class enemyAI : MonoBehaviour
{
    // Enemy stats
    public int curHp, maxHp, scoreToGive;

    // Movement
    public float moveSpeed, attackRange, yPathOffset;

    //Coordinates for a path
    private List<Vector3> path;

    // Enemy weapon
    private weapon weapon;

    // Target to follow
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Components
        weapon = GetComponent<weapon>();
        target = FindObjectOfType<playercontroller>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp = maxHp;
    }


    void UpdatePath()
    {
        // Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    
    void ChaseTarget()
    {
        if(path.Count == 0)
        {
            return;
        }

        // Move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
        {
            path.RemoveAt(0);
        }
    }

    // Applies damage to enemy
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once every frame
    void Update()
    {
        // Look at the target (player)
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        // Calculate the distance between the enemy and the player
        float dist = Vector3.Distance(transform.position, target.transform.position);
            
        // If within attackRange, shoot at target (player)
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
            
        // If enemy is too far away, chase targer (player)
        else
        {
            ChaseTarget();
        }
    }
}
