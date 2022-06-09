using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    public Transform shootPoint;
    public Vector2 shootDirection;

    private EnemyProjectile projectile;

    public float fireRate;
    private float nextFire;

    private void Start()
    {
        projectile = bullet.GetComponent<EnemyProjectile>();
        projectile.moveDirection = shootDirection;
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
            Instantiate(projectile, shootPoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}