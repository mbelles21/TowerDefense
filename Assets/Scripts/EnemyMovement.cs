using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.baseSpeed;
    }

    void GetNextWaypoint()
    {
        // the last waypoint
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndOfPath();
            return; // prevents exiting the loop until after destroy is done
        }
        
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndOfPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
