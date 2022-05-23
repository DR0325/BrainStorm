using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
<<<<<<< HEAD
    //GameObject target;

    public GameObject destroyEffect;
    public LayerMask isSolid;


    public Vector2 direction;
=======
    public float damage;

    public GameObject destroyEffect;
    public LayerMask isSolid;
>>>>>>> 70812c8fa7be6ceb978af50920d231d2c9b8b716


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
void Update()
    {
<<<<<<< HEAD

=======
>>>>>>> 70812c8fa7be6ceb978af50920d231d2c9b8b716
        RaycastHit2D hitInf = Physics2D.Raycast(transform.position, transform.up, distance, isSolid);
        if (hitInf.collider != null)
        {
            if (hitInf.collider.CompareTag("Enemy"))
            {
<<<<<<< HEAD
                Debug.Log("Hit");
=======
                hitInf.collider.GetComponent<Enemy>().TakeDamage(damage);
>>>>>>> 70812c8fa7be6ceb978af50920d231d2c9b8b716
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
<<<<<<< HEAD
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        transform.Translate(Vector3.up * (speed * Time.deltaTime));
=======
>>>>>>> 70812c8fa7be6ceb978af50920d231d2c9b8b716
    }

    void DestroyProjectile()
    {
<<<<<<< HEAD
        if (collision.gameObject.CompareTag("Enemy")) {}
        Destroy(this);

=======
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
>>>>>>> 70812c8fa7be6ceb978af50920d231d2c9b8b716
    }
}
