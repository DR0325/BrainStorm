using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;
    public GameObject[] typeOfEnemies;
    public int enemyAmount;
    public float rate;
}

public class EnemySpawner : MonoBehaviour
{
    
    public Wave[] waves;
    public Transform[] spawnPoints;
    public GameObject enemyCounter;

    private Wave currWave;
    private int currWaveNum;
    private float nextSpawnTime;

    public Vector3 drawSize;
    public bool draw;

    private bool canSpawn = true;
    [HideInInspector]
    public bool isTriggered = false;
    public bool isDone = false;
    public bool random = false;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnObject());
    }

    private void Update()
    {
        if (waves.Length != 0)
        {
            currWave = waves[currWaveNum];
        }
        SpawnSomething();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("CombatEnemy");
        if(totalEnemies.Length == 0)
        {
            if (currWaveNum + 1 != waves.Length)
            {
                if (!canSpawn)
                {
                    NextWave();
                }
            }
            else
            {
                if (!canSpawn)
                {
                    isDone = true;
                    enemyCounter.SetActive(false);
                }
            }
        }
        
    }

    void NextWave()
    {
        currWaveNum++;
        canSpawn = true;
    }

    void SpawnSomething()
    {
        GameObject ranEnemy;
        Transform ranPoint;

        if (canSpawn && isTriggered)
        {
            //if random
            ranEnemy = currWave.typeOfEnemies[Random.Range(0, currWave.typeOfEnemies.Length)];
            ranPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            ranEnemy.tag = "CombatEnemy";
            
            Instantiate(ranEnemy, ranPoint.position, Quaternion.identity);
            currWave.enemyAmount--;
            if(currWave.enemyAmount == 0)
            {
                canSpawn = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (draw)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < spawnPoints.Length; i++)
            {
               Gizmos.DrawCube(spawnPoints[i].transform.position, drawSize);
            }
        }
    }
}
