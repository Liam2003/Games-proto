using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject prefab;
    public int howMany; //how many targets the game initially spawns
    private int score; // players score
    public float spawnCooldown = 0;
    public float spawnTime; // how often a new target spawns into the game (s)
    // Use this for initialization
    void Start()
    {
        GameObject tmpTarget;
        targetMove am;
        spawnTime = spawnCooldown;

        for (int i = 0; i < howMany; i++) //loops for the amount of times that object are initially spawned in
        {
            tmpTarget = Instantiate(
                prefab, 
                new Vector3(Random.Range(-4, 4), Random.Range(1, 5), 0), //having the targets random spawn postion on the screen
                Quaternion.identity
             );

            am = tmpTarget.GetComponent<targetMove>();

            am.mx = Random.Range(-99, 99);
            am.my = Random.Range(-99, 99);
            am.rotz = Random.Range(-3, 99);
        }  
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime; //the code for the timer for when a new target is spawned on screen

        if (spawnTime <= 0){
            spawn(); //calls "void spawn()"
            
            spawnTime = spawnCooldown;
        }
    }
    void spawn(){   
        GameObject tmpTarget;
        targetMove am;
         tmpTarget = Instantiate(
                prefab, 
                new Vector3(Random.Range(-4, 4), Random.Range(1, 5), 0), //spawns a new target on the screen at a random position
                Quaternion.identity
             );

            am = tmpTarget.GetComponent<targetMove>();
            am.mx = Random.Range(-99, 99);
            am.my = Random.Range(-99, 99);
            am.rotz = Random.Range(-3, 99);
    }
    public int getScore()
    {
        return score;
    }
    public void setScore(int s) //code for keeping track of player score once they destroy a target on screen
    {
        score = s;
    }
    public void adjustScore(int s)
    {
        score += s;
        Debug.Log("Score is " + score);// prints the up to date score in the console for the player to view
    }
}

