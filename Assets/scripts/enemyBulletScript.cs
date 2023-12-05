using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private Rigidbody2D myRigid;
    public GameObject myPart;
    private GameStateManager gsm;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody2D>();    
        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>();
        
    }
    // Update is called once per frame
    void Update()
    {
        myRigid.AddForce(this.transform.up * 1); //sets the speed of the enemies bullet speed (1)
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {      
        GameObject part;
        if (collision.gameObject.tag == "Player") {    //if the enemy shoots the player then the player is destroyed
                part = Instantiate(myPart,
                this.transform.position,
                this.transform.rotation);
               
               Destroy (part, 100); //displayed different image to show player has been killed
               
                //gsm.adjustScore(1);
            Destroy(collision.gameObject); //destroys the player object
         
            Destroy(collision.gameObject);
        } 

Destroy(this.gameObject);
   }
}
