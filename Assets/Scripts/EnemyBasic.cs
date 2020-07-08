using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBasic : MonoBehaviour
{
    public Transform playerPosition;

    private Rigidbody2D rb;
    private Seeker seeker;

    public float stopDistance;
    public float speed;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    public bool isChampion;

    void Start()
    {
        //playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        seeker = this.GetComponent<Seeker>();

        InvokeRepeating("updatePath", 0f, .5f);
    } 

    void updatePath()
    {
        if (seeker.IsDone())
        {
            //print("hi");
            seeker.StartPath(rb.position, playerPosition.position, onPathComplete);
        }
    }

    void onPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    private void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        float distanceFromPlayer = Vector2.Distance(rb.position, playerPosition.position);

        if(distanceFromPlayer > stopDistance)
        {
            rb.AddForce(force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            HealthSystem playerHs = collision.collider.GetComponent<HealthSystem>();
            if (isChampion)
            {
                playerHs.damage(20);
            }
            else
            {
                playerHs.damage(10);
            }
            if (playerHs.getGracePeriod() <= 0)
            {
                playerHs.setGracePeriod();
            }
        }
    }


}
