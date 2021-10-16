using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Spawner : MonoBehaviour
{
    public UFO ufoPrefab;
    public float spawnRate = 2.0f;
    public float spawnAmount = 1f;
    public float spawnDistance = 15.0f;
    public float trajectoryVariance = 15.0f;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for(int i=0; i<this.spawnAmount;i++)
        {
            Vector3 spawnDirection=Random.insideUnitCircle.normalized * this.spawnDistance;

            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);

            Quaternion rotation= Quaternion.AngleAxis(variance, Vector3.forward);

            UFO ufo = Instantiate(this.ufoPrefab, spawnPoint, rotation);
     
        }
    }
}
