using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController[] enemiesToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns = 0.5f;
    private float spawnCounter;

    public int amountToSpawn = 15;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    void Update()
    {
        if (amountToSpawn > 0)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;
                
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation);

                amountToSpawn--;
            }
        }
    }
}