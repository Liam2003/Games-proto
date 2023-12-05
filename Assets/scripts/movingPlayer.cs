using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlayer : MonoBehaviour{
    public string left;
    public string right; //variables to assign the keys to move the player left and right
    public string fire;
    public GameObject bullet; //gameobject for the bullet the player shoots
    public GameObject gs;
    public float lastFired;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3 (0, 0, 0);

        if (Input.GetKey(left)) //moving the player left 
        {
            move = new Vector3(-0.01f, 0, 0); //sets movement speed
        }

        if (Input.GetKey(right)) { //moving the player right
            move = new Vector3(0.01f, 0, 0); //sets movement speed
        }

        this.transform.Translate(move);

        GameObject tmpBullet;
        if (Input.GetKey(fire)) //if the player chooses to shoot this loop will run
        {
            
            if (Time.time > lastFired + 1) //checking the player isnt shooting to fast, time betwen bullets
            {
                Debug.Log("Fired"); //console will print that the player has shot a bullet
                tmpBullet = Instantiate(bullet, this.transform.position + //spawns the bullet into the game
                     (this.transform.up), this.transform.rotation);// moves the bullet upwards on the screen
                lastFired = Time.time;
                gs.GetComponent<AudioSource>().Play(); //sound effect when the player shoots
            }
        }

        
        
    }
}
