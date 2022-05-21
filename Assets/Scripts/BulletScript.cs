using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] public static BulletScript BulletScriptInstance;
    GameObject target;
    public float speed;
    private int bulletType;
    [SerializeField]
    public int numberOfBullets;// for bullet type 4 use
    [SerializeField]
    public float startAngle; //for bullet type 4 use
    public float endAngle; // for bullet type 4 use
    public float fireRate;
    private float angle = 0f;
    Rigidbody2D bulletRB;

    private Vector2 bulletMoveDirection;

    private void Awake()
    {
        BulletScriptInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void InvokingFire(int bulType)
    {
        //bulletType = bulType;
        //if (bulletType == 0 || bulletType == 1)
        //{
        //    InvokeRepeating("Fire", 1f, fireRate);
        //}
        //else if (bulletType == 2 || bulletType == 3)
        //{
        //    InvokeRepeating("Fire", .1f, fireRate);
        //}

    }

    public void Fire(int bulType) 
    {
     
        float bulDirX;
        float bulDirY;
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        if (bulletType == 0)
        {
            GameObject bul = BulletPool.BulletPoolInstanse.GetBullet();
            Vector2 bulDir = (target.transform.position - transform.position).normalized * speed;
            
           bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        }
        else if(bulletType == 1) // homing shot
        {
            GameObject bul = BulletPool.BulletPoolInstanse.GetBullet();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (bulletType == 2)//bullet circles enemy // may need additional work with keeping the bullet moving, something to do with update.
        {
            for (int i = 0; i <= 1; i++)
            {
                 bulDirX = transform.position.x + Mathf.Sin(((angle + 180 * i) * Mathf.PI) / 180f);
                 bulDirY = transform.position.y + Mathf.Cos(((angle + 180 * i) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.BulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            }

            angle += 10f;

            if (angle >= 360f)
            {
                angle = 0f;
            }
        }
        else if(bulletType == 3)//spray shot
        {
            Vector2 targetDir = (target.transform.position - transform.position).normalized * speed;
            float targetAngle = Mathf.Sin(targetDir.y / targetDir.x);
            float angleStep = (endAngle - startAngle) / numberOfBullets;
            float currentAngle = targetAngle - ((startAngle + endAngle) / .65f);

            for(int i = 0; i < numberOfBullets + 1; i++)
            {
                bulDirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
                bulDirY = transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.BulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

                currentAngle += angleStep;
            }
        }

    }


   


    // Update is called once per frame
    void Update()
    {
   
    }



}
