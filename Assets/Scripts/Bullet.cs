using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 bulletMoveDirection;
    public float speed;
    public float bulletDuration;
    public Vector2 bulletStartPosition;
    public GameObject bulletSprite;
    public int firingPattern;
    

    [SerializeField] public static Bullet BulletInstance;

    private void Start()
    {
        BulletInstance = this;
    }
        private void OnEnable()
    {
       // bulletStartPosition = 
       Invoke("Destroy", bulletDuration * Time.deltaTime);
        transform.position = bulletStartPosition;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (firingPattern == 0)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(bulletMoveDirection * speed * Time.deltaTime);
        }
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
