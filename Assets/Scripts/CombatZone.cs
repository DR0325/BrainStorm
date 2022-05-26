using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZone : MonoBehaviour
{
    public Transform cam;

   
    public Transform camLock;
    public Transform enemySpawner;
    public GameObject[] Doors;

    private bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawner.GetComponent<EnemySpawner>().isDone == true)
        {
            cam.GetComponent<CameraLook>().inCombat = false;
            cam.GetComponent<CameraLook>().followPlayer = true;
            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].GetComponent<DoorScript>().OpenDoors();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isTriggered == false)
        {
            if (collision.tag == "Player")
            {
                isTriggered = true;
                enemySpawner.GetComponent<EnemySpawner>().isTriggered = true;
                cam.GetComponent<CameraLook>().camTarget = camLock;
                cam.GetComponent<CameraLook>().inCombat = true;
                for (int i = 0; i < Doors.Length; i++)
                {
                    Doors[i].GetComponent<DoorScript>().MoveDoors();
                }
            }
        }
    }
}
