using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public Transform enemyGFX;
    Seeker seeker;
    Rigidbody2D rb;

    ScoreManager sm;
    //PlayerMovement pm;
    
        // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //pm = target.GetComponent<PlayerMovement>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }
    void UpdatePath() {
        if(seeker.IsDone() && target)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p) {
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null || !target)
            return;

        if(currentWaypoint > path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWayPointDistance) {
            currentWaypoint++;
        }

        if(force.x >= 0.01f) {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(force.x <= -0.01f) {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D info) {
        
        if(info.gameObject.CompareTag("Player")) {

            //destroy player
            Destroy(info.gameObject);

            //if(pm) {
            //    pm.Respawn();
            //}
            //Debug.Log("Player killed!");
            sm.EndOfGame();
        }
    }
}
