using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    //GameObject target;

    public GameObject destroyEffect;
    public LayerMask isSolid;


    public Vector2 direction;
    public float damage;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
void Update()
    {
        RaycastHit2D hitInf = Physics2D.Raycast(transform.position, transform.up, distance, isSolid);
        if (hitInf.collider != null)
        {
            if (hitInf.collider.CompareTag("Enemy"))
            {

                Debug.Log("Hit");
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

        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }

    //void DestroyProjectile()
    //{

    //    if (collision.gameObject.CompareTag("Enemy")) {}
    //    Destroy(this);


    //    Instantiate(destroyEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);

    //}
}
