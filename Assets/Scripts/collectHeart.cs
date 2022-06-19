using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectHeart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
        {
        if (other.CompareTag("Player")) 
            {
            if (other.GetComponent<Player>() == null)
            {
                other.GetComponentInParent<Player>().currentHealth += 50;
            }
            else
            {
                other.GetComponent<Player>().currentHealth += 50;
            }

            if(other.GetComponent<Player>().currentHealth > 100)
            {
                other.GetComponent<Player>().currentHealth = 100;
            }
            
            Destroy(gameObject);
            }
        }
}
