using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Sprite [] sprites;
    private SpriteRenderer spriteRenderer;
    public float size = 1.0f;
    public float maxLifeTime = 10.0f;
    private Rigidbody2D ridgidB;
    public float speed = 30.0f; 
    private Transform target;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ridgidB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        ridgidB.mass = this.size;
    }
    
    void Update()
    {    
         transform.position = Vector3.MoveTowards(transform.position, target.position, speed* Time.deltaTime);  
    }

    public void SetTrajectory(Vector2 direction)
    {
        ridgidB.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {   
            FindObjectOfType<GameManager>().UFODestoyed(this);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Laser")
        {   
            FindObjectOfType<GameManager>().UFODestoyed(this);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {   
            FindObjectOfType<GameManager>().UFODestoyed(this);
            Destroy(this.gameObject);
        }
       
    }
    
}
