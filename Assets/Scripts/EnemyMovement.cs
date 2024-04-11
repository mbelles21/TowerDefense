using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    // private int wavepointIndex = 0;

    private Enemy enemy;
    private NavMeshAgent myAgent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        // target = Waypoints.waypoints[0];
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = enemy.baseSpeed;
        myAgent.updateRotation = false;
        
        myAgent.destination = target.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
        */

        
        
        if (myAgent.remainingDistance <= myAgent.stoppingDistance)
        {
            EndOfPath();
            return;
        }

        // enemy.speed = enemy.baseSpeed;
        myAgent.speed = enemy.baseSpeed;
    }

    /*
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
    */

    void EndOfPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    

    void CheckPos()
    {
        
    }
}
