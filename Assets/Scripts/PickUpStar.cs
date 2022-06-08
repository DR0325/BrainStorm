using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpStar : MonoBehaviour
{
    private PickUpManager pUpManager;

    private void Start()
    {
        pUpManager = FindObjectOfType<PickUpManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("POOP");
            pUpManager.addStar();
            Destroy(gameObject);
            //Destroy(gameObject);
        }
    }
}
