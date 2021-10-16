using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public float moveSpeed;
   
   public Rigidbody2D rigidB;

   Vector2 movement;
   Vector2 mousePos;

   public GameObject upWall;
   public GameObject downWall;
   public GameObject leftWall;
   public GameObject rightWall;

   public GameObject player;
   public Camera cam;

   public float anglee;

    void Update()
    {
         if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
         {  
             moveSpeed=2f;
             transform.Translate(Vector2.up*moveSpeed*Time.fixedDeltaTime);
         }
         else
         {
            moveSpeed=0f;
         }
          
        //  if (Input.GetKey(KeyCode.LeftArrow))
        //  {
        //      transform.Translate(Vector2.left*moveSpeed*Time.fixedDeltaTime);
        //  }  
        //  else if (Input.GetKey(KeyCode.RightArrow))
        //  {
        //      transform.Translate(Vector2.right*moveSpeed*Time.fixedDeltaTime);
        //  } 
           

         triggerWall();

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         anglee = transform.localEulerAngles.z;
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos -rigidB.position;
        float angle =Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg-90f;
        rigidB.rotation=angle;
    }
    
    void triggerWall()
    {
        if (player.transform.position.y<downWall.transform.position.y+1f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y+10);
        }
        else if (player.transform.position.y>upWall.transform.position.y-1f)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y-10);
        }
        
    }
    void OnGUI() {
    GUI.Label (new Rect (5,15,500,25), "Player position: X:" + transform.position.x + 
    " Y: " + transform.position.y + " Z: " + transform.position.z);
    GUI.Label (new Rect (5,25,100,25), "Speed:" + moveSpeed);
    GUI.Label (new Rect (5,35,100,25), "Angle:" + anglee);

}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag =="Asteroid")
        {
            rigidB.velocity = Vector3.zero;

            rigidB.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        } else if (coll.gameObject.tag =="UFO")
        {
            rigidB.velocity = Vector3.zero;

            rigidB.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
