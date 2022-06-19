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
    public GameObject spawnParticles;
    private GameObject[] totalEnemies;

    private Wave currWave;
    private int currWaveNum;
    private float nextSpawnTime;

    private GameObject ranEnemy;
    private Transform ranPoint;

    public Vector3 drawSize;
    public bool draw;

    private bool canSpawn = true;
    [HideInInspector]
    public bool isTriggered = false;
    public bool isDone = false;
    public bool random = false;
    private bool iHateThis = false;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("CombatEnemy");
        //StartCoroutine(SpawnObject());
    }

    private void Update()
    {
        if (waves.Length != 0)
        {
            currWave = waves[currWaveNum];
        }
        SpawnSomething();
        if (iHateThis == true)
        {
            totalEnemies = GameObject.FindGameObjectsWithTag("CombatEnemy");
            if (totalEnemies.Length == 0 && iHateThis == true)
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
    }

    void NextWave()
    {
        currWaveNum++;
        iHateThis = false;
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
            if(random == false)
            {
                ranPoint = spawnPoints[count];
            }
            ranEnemy.tag = "CombatEnemy";

            Instantiate(spawnParticles, ranPoint.position, spawnParticles.transform.rotation);
            StartCoroutine(waityWaiterthatWaits(ranEnemy, ranPoint));
            count++;
            currWave.enemyAmount--;
            if(currWave.enemyAmount == 0)
            {
                canSpawn = false;
                count = 0;
            }
        }
    }

    private IEnumerator waityWaiterthatWaits(GameObject enemy, Transform point)
    {
        yield return new WaitForSeconds(2);

        Instantiate(enemy, point.position, Quaternion.identity);
        iHateThis = true;
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
