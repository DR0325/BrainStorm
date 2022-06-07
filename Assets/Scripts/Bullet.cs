using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 bulletMoveDirection;
    public float speed;
    public float bulletDuration;
    public Vector3 bulletStartPosition;
    public GameObject bulletSprite;
    public int firingPattern;
    public float xPos;
    public float yPos;
    public float damage;
    public float distance;
    public GameObject destroyEffect;
    public LayerMask isSolid;


    //public static Bullet BulletInstance;

    private void Start()
    {
        //BulletInstance = this;
    }
        private void OnEnable()
    {
       // bulletStartPosition = 
       Invoke("Destroy", bulletDuration);
        bulletStartPosition = transform.position;
        xPos = transform.position.x;
        yPos = transform.position.y;

    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (this != null)
        {
            RaycastHit2D hitInf = Physics2D.Raycast(transform.position, transform.up, distance, isSolid);
            if (firingPattern == 0)
            {

                GameObject target = GameObject.FindGameObjectWithTag("Player");

                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            }
            else
            {
                transform.Translate(bulletMoveDirection * speed * Time.deltaTime);
            }

            if (hitInf.collider != null)
            {
                if (firingPattern != 0)
                {
                    if (hitInf.collider.CompareTag("Player"))
                    {
                        hitInf.collider.GetComponent<Player>().TakeDamage(damage);
                        DestroyProjectile();
                    }
                }
                else
                {
                    if (hitInf.collider.IsTouchingLayers(isSolid))
                    {
                        if (hitInf.collider.GetComponent<Player>() != null)
                        {
                            hitInf.collider.GetComponent<Player>().TakeDamage(damage);
                        }
                        DestroyProjectile();
                    }
                }
            }
        }
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy();
    }

    public void SetMoveDirection(Vector2 dir)
    {
        bulletMoveDirection = dir;
    }


    private void OnDisable()
    {
        CancelInvoke();
    }

    }
