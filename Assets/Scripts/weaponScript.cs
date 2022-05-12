using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapon")]
public class weaponScript : ScriptableObject
{
    public Sprite currWeaponSpr;
    public GameObject projectile;

    public float _offset;

    public float fireRate;

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectile, GameObject.Find("FirePoint").transform.position, GameObject.Find("RotationPoint").transform.rotation);
    } 
}
