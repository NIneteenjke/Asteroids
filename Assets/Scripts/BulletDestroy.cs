using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.8f);
        Destroy(this.gameObject);//добавить время(,0.8f)
    }



}
