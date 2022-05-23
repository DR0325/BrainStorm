using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public weaponScript weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().currWeapon = weapon;
            other.transform.GetChild(1).GetComponentInChildren<SpriteRenderer>().sprite = weapon.currWeaponSpr;
            Destroy(gameObject);
        }
    }

}
