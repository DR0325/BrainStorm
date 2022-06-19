using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private AudioSource enemyHitSound;
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;

    public GameObject destroyEffect;
    public LayerMask isSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
void Update()
    {
        Physics2D.IgnoreLayerCollision(12, 10, true);
        RaycastHit2D hitInf = Physics2D.Raycast(transform.position, transform.up, distance, isSolid);
        if (hitInf.collider != null)
        {
            if (hitInf.collider.CompareTag("Enemy") || hitInf.collider.CompareTag("CombatEnemy"))
            {
                enemyHitSound.Play();
                hitInf.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
