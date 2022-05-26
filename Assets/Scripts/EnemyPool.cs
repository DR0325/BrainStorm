using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    public static EnemyPool EnemyPoolInstanse;

    [SerializeField]
    private GameObject[] enemies;
    private bool notEnoughEnemies = true;
    

    private List<GameObject> enemyPool;

    private void Awake()
    {
        EnemyPoolInstanse = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new List<GameObject>();
    }

    public GameObject GetEnemy(int enemy, Vector3 spawnLocation)
    {
        if (enemyPool.Count > 0)
        {
            for (int i = 0; i < enemyPool.Count ; i++)
            {
                if (enemyPool[i].activeInHierarchy && enemyPool[i] == enemies[enemy])
                {
                    return enemyPool[i];
                }
            }
        }
        if (notEnoughEnemies)
        {
            GameObject en = Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
            en.SetActive(false);
            enemyPool.Add(en);
            return en;
        }
        return null;
    }
}
