using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject pointA; //setting the limits for the enemy movement
    public GameObject pointB;
    private Rigidbody2D rb;
    public float speed; //speed of enemy movement
    private Transform currentPoint;

    public GameObject bullet; //game object for the bullet the enemy shoots
    public float lastFired;

    public float spawnCooldown = 0;
    public float spawnTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0 );
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform){
            currentPoint = pointA.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
        }
        if (spawnTime > 0) spawnTime -= Time.deltaTime;

             if (spawnTime <= 0){//timer to randomly spawn bullets form the enemy
                spawn();
                spawnTime = spawnCooldown;
             }
    }
    void spawn(){ 
        GameObject tmpBullet;
        if (Time.time > lastFired + 1)//loop for shooting the enemies bullets
            {
                Debug.Log("enemy fired"); //prints in the console when the enemy shoots
                tmpBullet = Instantiate(bullet, this.transform.position +
                     (this.transform.up), this.transform.rotation);
                lastFired = Time.time;
            }
    }
}

