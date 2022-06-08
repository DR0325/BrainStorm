using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemySpawner[] orderOfSpawnerTrigger;
    public int currentSpawner;
    public GameObject LevelComponentManipulate;
    public bool IsSpawnerActive = false;
    public bool doesPlatformAppear;
    public bool doesPlatformMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpawnerActive)
        {
            if (orderOfSpawnerTrigger[currentSpawner] != null)
            {
                if (orderOfSpawnerTrigger[currentSpawner].isDone)
                {
                    if (orderOfSpawnerTrigger[currentSpawner + 1] != null)
                    {
                        orderOfSpawnerTrigger[currentSpawner + 1].isTriggered = true;
                    }
                    else
                    {
                        if (LevelComponentManipulate != null)
                        {
                            if (doesPlatformAppear)
                            {
                                LevelComponentManipulate.SetActive(true);
                            }
                            if(doesPlatformMove)
                            {
                                LevelComponentManipulate.GetComponent<LevelComponents>().doesPlatformMove = true;
                            }
                        }
                    }
                }
            }
            else
            { }
        }
    }
}
