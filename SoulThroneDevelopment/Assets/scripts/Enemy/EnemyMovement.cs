using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float patrolSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform[] patrolWaypointsArray;
    private Queue<Transform> patrolWaypoints;
    private Transform currentWaypoint;

    public Vector2 lastPos, currPos;

    // Start is called before the first frame update
    void Start()
    {
        patrolWaypoints = new Queue<Transform>(patrolWaypointsArray);
        currentWaypoint = patrolWaypoints.Peek();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        Patrol();
        
    }

    void Patrol()
    {
        lastPos = transform.position;
        currPos = Vector2.MoveTowards(transform.position, currentWaypoint.position, patrolSpeed * Time.fixedDeltaTime);
        transform.position = currPos;
        if (transform.position == currentWaypoint.position)
        {
            patrolWaypoints.Enqueue(currentWaypoint);
            currentWaypoint = patrolWaypoints.Dequeue();
        }
    }
}
