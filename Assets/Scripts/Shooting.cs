using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject laserPrefab;

    public float bulletForce = 20f;
    public float laserForce = 35f;

    public float cd = 0;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    

        if( Input.GetKeyDown(KeyCode.Mouse1)&cd<=0)
        {
            laserShoot();
        }else if (cd>0)
        {
            cd -=Time.deltaTime;
            if(cd<0.0f)
            {
                cd=0;
            }
        }

        
    }
    void OnGUI() {
    GUI.Label (new Rect (5,55,100,25), "CD:" + cd);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidB = bullet.GetComponent<Rigidbody2D>();
        rigidB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void laserShoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidB = laser.GetComponent<Rigidbody2D>();
        rigidB.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
        cd = 5f;
    }

}
