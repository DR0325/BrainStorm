using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelTrigger : MonoBehaviour
{

    private bool isTriggered = true;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTriggered == false)
        {
            isTriggered = true;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAA");
            LevelTimer.instance.BeginTimer();
        }
    }
}
