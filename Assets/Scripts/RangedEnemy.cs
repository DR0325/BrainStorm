using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    public Transform shootPoint;

    public float fireRate;
    private float nextFire;

    private void Start()
    {
        nextFire = Time.deltaTime;
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}