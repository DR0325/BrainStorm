using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
     //public static BulletScript BulletScriptInstance;
    GameObject target;
    public float speed;
    public int bulletType;
    [SerializeField]
    private int numberOfBullets;// for bullet type 4 use
    public float startAngle; //for bullet type 4 use
    public float endAngle; // for bullet type 4 use
    private float angle = 0f;
    Rigidbody2D bulletRB;
    Bullet bul;
    Enemy enemy;
    private Vector2 bulletMoveDirection;
    private Transform bulletStartPosition;
    

    //private void Awake()
    //{
    //    BulletScriptInstance = this;
    //}


    public void InvokeRepeat(int bulletType, float pauseRate, float fireRate, Enemy EnemyInstance)
    {
        enemy = EnemyInstance;
        switch (bulletType)
        {
            case 0:
                InvokeRepeating("Fire", pauseRate*Time.deltaTime, fireRate * Time.deltaTime);
                break;
            case 1:
                InvokeRepeating("Fire2",pauseRate * Time.deltaTime,fireRate * Time.deltaTime);
                break; 
            case 2:    
                InvokeRepeating("Fire3",pauseRate * Time.deltaTime, fireRate * Time.deltaTime);
                break; 
            case 3:   
                InvokeRepeating("Fire4",pauseRate * Time.deltaTime, fireRate * Time.deltaTime);
                break;
        }
    }

    public void CancelInvokeRepeat()
    {
        CancelInvoke();
    }

    public void Fire()
    {
        bul = GameManager.Instance.bulletPool.GetBullet(0);
        bul.transform.position = enemy.bulletParent.transform.position;
        bul.gameObject.SetActive(true);

    }

    public void Fire2()
    {

        for (int i = 0; i <= 1; i++)
        {
           float bulDirX = transform.position.x + Mathf.Sin(((angle + 180 * i) * Mathf.PI) / 180f);
           float bulDirY = transform.position.y + Mathf.Cos(((angle + 180 * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
           Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            bul = GameManager.Instance.bulletPool.GetBullet(2);
         
            bul.transform.rotation = transform.rotation;
            bul.gameObject.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        }

        angle += 10f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    public void Fire3()
    {
        Vector2 targetDir = (GameManager.Instance.player.transform.position - transform.position).normalized * speed;
        float targetAngle = Mathf.Sin(targetDir.y / targetDir.x);
        float angleStep = (endAngle - startAngle) / numberOfBullets;
        float currentAngle = targetAngle - ((startAngle + endAngle) / .65f);

        for (int i = 0; i < numberOfBullets + 1; i++)
        {
           float bulDirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180f);
           float bulDirY = transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

             bul = GameManager.Instance.bulletPool.GetBullet(1);
            //bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.gameObject.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            currentAngle += angleStep;
        }
    }

    public void Fire4()
    {

   
            float bulDirX = transform.position.x + Mathf.Sin((angle + 180 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle + 180 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

             bul = GameManager.Instance.bulletPool.GetBullet(1);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.gameObject.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        

        angle += 10f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }







    // Update is called once per frame
    void Update()
    {
   
    }



}
