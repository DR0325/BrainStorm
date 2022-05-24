using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 bulletMoveDirection;
    public float speed;
    public float bulletDuration;
    //public Vector2 bulletStartPosition;
    

    [SerializeField] public static Bullet BulletInstance;

    private void Awake()
    {
        BulletInstance = this;
    }
        private void OnEnable()
    {
       Invoke("Destroy", bulletDuration);
        //transform.position = bulletStartPosition;

    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletMoveDirection * speed * Time.deltaTime);
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
