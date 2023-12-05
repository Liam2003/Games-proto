using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    private Rigidbody2D myRigid;
    public GameObject myPart;
    private GameStateManager gsm;

    // Use this for initialization
    void Start () {
        myRigid = this.GetComponent<Rigidbody2D>();    
        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>();
    }
    // Update is called once per frame
    void Update () {

        myRigid.AddForce(this.transform.up * 30); //shoots the bullets upwards on the screen

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {      
        GameObject part;
        if (collision.gameObject.tag == "target") { //when a object with the tag "target" is hit with a bullet from the player it will be destroyed 
            
            part = Instantiate(myPart,
                this.transform.position,
                this.transform.rotation);               
                Destroy (part,1);  //when a target is hit another image is displayed for 1 second (an explosion)             
                gsm.adjustScore(1);
            Destroy(collision.gameObject); //destroys the game object hit
            Destroy(collision.gameObject);
        } 
Destroy(this.gameObject);
    }
}

