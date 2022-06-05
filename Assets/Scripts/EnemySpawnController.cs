using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemySpawner[] orderOfSpawnerTrigger;
    public int currentSpawner;
    public GameObject platformAppear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(orderOfSpawnerTrigger[currentSpawner].isDone)
        {
            if(orderOfSpawnerTrigger[currentSpawner + 1] !=null)
            {
                orderOfSpawnerTrigger[currentSpawner + 1].isTriggered = true;
            }
            else
            {
                platformAppear.SetActive(true);
            }
        }
    }
}
