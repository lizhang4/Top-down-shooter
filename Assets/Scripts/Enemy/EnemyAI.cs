using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 20f;

    public float nextWayPointDistance = 3f;
    public bool stopMoving;

    private Path path;
    private int currentWayPoint = 0;
    public bool reachedEndOfPath = false;
    private Vector2 initialPosition;

    private Seeker seeker;
    private Rigidbody2D rb;


    private void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        currentWayPoint = 0;
        //InvokeRepeating("UpdatePath", 0f,0.5f);
    }

    public void UpdatePath(Vector3 targetPos) {
        if (seeker.IsDone()) {
            seeker.StartPath(rb.position, targetPos, OnPathComplete);
            // foreach (Vector3 v in path.vectorPath) {
            //     Debug.Log(v);

            // }
        }
    }

    private void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWayPoint = 0;
        }
    }

    // private void FixedUpdate() {
        
    //     if (path == null) {
    //         return;
    //     }

    //     if ( currentWayPoint >= path.vectorPath.Count) {
    //         reachedEndOfPath = true;
    //         return;
    //     }
    //     else {
    //         reachedEndOfPath = false;
    //     }

    //     Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position ).normalized;

    //     rb.velocity = direction * 1;

    //     float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
    //     // if (currentWayPoint == 0) {
    //     //     float currentPathDistance = Vector2.Distance(path.vectorPath[currentWayPoint-1], path.vectorPath[currentWayPoint])

    //     // }
    //     // float currentPathDistance = Vector2.Distance(path.vectorPath[currentWayPoint-1], path.vectorPath[currentWayPoint])

    //     if(distance < nextWayPointDistance) {
    //         currentWayPoint++;
    //     }
        
    // }

    public void MoveToward(float speed) {
        if (path == null) {
            //rb.velocity = Vector2.zero;
            return;
        }

        if(currentWayPoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            //Debug.Log("End of Path");
            //rb.velocity = Vector2.zero;

            return;
        }
        else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        
        rb.velocity = direction * speed;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance) {
            currentWayPoint++;
        }
    }
}
