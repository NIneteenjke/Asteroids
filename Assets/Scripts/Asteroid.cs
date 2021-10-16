using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite [] sprites;
    private SpriteRenderer spriteRenderer;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f; 
    public float maxLifeTime = 10.0f;
    private Rigidbody2D ridgidB;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ridgidB = GetComponent<Rigidbody2D>();
    }

   private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value*360.0f);

        this.transform.localScale = Vector3.one * this.size;
        
        ridgidB.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        ridgidB.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet" )
        {
            if((this.size*0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestoyed(this);
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Laser")
        {
            FindObjectOfType<GameManager>().AsteroidDestoyed(this);
            Destroy(this.gameObject);
        }
       
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;

        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);

        half.size = this.size * 0.5f;

        half.SetTrajectory(Random.insideUnitCircle.normalized*this.speed);
    }
}
