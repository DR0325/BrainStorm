using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public weaponScript weapon;
    public Transform weaponHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().currWeapon = weapon;
            weaponHolder.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.currWeaponSpr;
            Destroy(gameObject);
        }
    }

}
