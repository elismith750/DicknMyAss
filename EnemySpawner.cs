using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private bool spawnEnabled = true;
    
    private float currentTime;
    private float timeTillEnemy;


    private void Start()
    {
        currentTime = 0;
        timeTillEnemy = 2;
    }

    private void Update()
    {

        if(spawnEnabled)
        { 
            currentTime += Time.deltaTime; 

            if (currentTime > timeTillEnemy)
            {
                SpawnEnemy();
                currentTime = 0;
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = EnemyPool.instance.GetPooledObject();

        if (enemy != null)
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
        }
    }
}
