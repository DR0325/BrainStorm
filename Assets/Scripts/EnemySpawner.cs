using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public int howMandyEnemies;
    public float howOften;
    public Vector3 drawSize;
    public bool draw;
    //private float howOftenCounter;
    [SerializeField]
    public GameObject[] spawnObjects;
    public GameObject[] spawnObjectsClones;
    public GameObject[] spawnPoints;// publicTransfor[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnObject());
        

    }

    void SpawnSomething()
    {
        spawnObjectsClones[0] = Instantiate(spawnObjects[0], spawnPoints[0].transform.position, Quaternion.Euler(0,0,0));
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(howOften);
        for (int i = 0; i < howMandyEnemies; i++)
        {
            int selectedSpawnPoint = Random.Range(0, 3);
            int randObject = Random.Range(0, spawnObjects.Length);
            // GameObject newEnemy = Instantiate(spawnObjects[randObject], spawnPoints[selectedSpawnPoint].transform.position, Quaternion.identity);
            GameObject en = EnemyPool.EnemyPoolInstanse.GetEnemy(0, spawnPoints[selectedSpawnPoint].transform.position);
            en.transform.position = spawnPoints[selectedSpawnPoint].transform.position;
            en.transform.rotation = transform.rotation;
            en.SetActive(true);
        }
        StartCoroutine(SpawnObject());

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
