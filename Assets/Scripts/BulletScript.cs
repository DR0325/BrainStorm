using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class BulletScript
{
     //public static BulletScript BulletScriptInstance;
 

    static float angle = 0f;
    static float stepAngle;
    static Rigidbody2D bulletRB;
    static GameObject bul;
    static GameObject pulledBullet;
    static Enemy enemy;
    static Transform bulletTransform;

    



    public static void InvokeRepeat(GameObject enemyInstance, GameObject bulletInstance, Transform bulTransform)
    {
        enemy = enemyInstance.GetComponent<Enemy>();
        stepAngle = enemy.stepAngle;
        bul = bulletInstance;
        bulletTransform = bulTransform;
        switch (enemy.enemyFireingType)
        {
            case 0:
                Fire();
                break;
            case 1:
                Fire2();
                break; 
            case 2:    
                Fire3();
                break; 
            case 3:   
                Fire4();
                break;
        }
    }

    public static void Fire()
    {
        pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
        pulledBullet.gameObject.SetActive(true);
        pulledBullet.transform.position = enemy.bulParent.position;
        pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
        pulledBullet.GetComponent<Bullet>().damage = enemy.damage;
        pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
    }

    public static void Fire2()
    {

        for (int i = 0; i <= 1; i++)
        {
            pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
            pulledBullet.gameObject.SetActive(true);
            pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
            pulledBullet.transform.position = enemy.bulParent.position;
            pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
            pulledBullet.GetComponent<Bullet>().damage = enemy.damage;

            float bulDirX =  pulledBullet.transform.position.x + Mathf.Sin(((angle + 180 * i) * Mathf.PI) / 180f);
            float bulDirY = pulledBullet.transform.position.y + Mathf.Cos(((angle + 180 * i) * Mathf.PI) / 180f);
          
            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - bulletTransform.position).normalized;        
            pulledBullet.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }
        Debug.Log("fire2 step 3");
        angle += stepAngle;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    public static void Fire3()
    {
        pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
        pulledBullet.gameObject.SetActive(true);
        pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
        pulledBullet.transform.position = enemy.bulParent.position;
        pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
        pulledBullet.GetComponent<Bullet>().damage = enemy.damage;
       
        Vector3 target = GameManager.Instance.player.transform.position - enemy.bulParent.position;
        pulledBullet.GetComponent<Bullet>().SetMoveDirection(target);
    }

    public static void Fire4()
    {

      

        //float spread = enemy.endAngle - enemy.startAngle;
        //float angleStep = spread / enemy.numberOfBullets;


        //float currentAngle = (float)(zRotation + ((spread/2 * Math.PI)/180) );
        //Debug.Log("fire4 step 1");
        //for (int i = 0; i < enemy.numberOfBullets + 1; i++)
        //{

            Vector3 targetAngle = GameManager.Instance.player.transform.position - enemy.bulParent.position;
            float spread = enemy.endAngle - enemy.startAngle;
            float angleStep = spread / enemy.numberOfBullets;

            Vector3 CurrentAngle = Quaternion.Euler(0, 0, -spread / 2) * targetAngle; // starting the current at the one extreme end rotating the target angle by half of the full spread

            for (int i = 0; i < enemy.numberOfBullets;i++) // loop for all bullets
            {
            /////////////////////////////
            //Bullet Creation code here//
            /////////////////////////////
            pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
            pulledBullet.SetActive(true);
            pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
            pulledBullet.transform.position = enemy.bulParent.position;//bullet start position
            pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
            pulledBullet.GetComponent<Bullet>().damage = enemy.damage;
            pulledBullet.GetComponent<Bullet>().SetMoveDirection(new Vector2(CurrentAngle.x, CurrentAngle.y));
                CurrentAngle = Quaternion.Euler(0, 0, angleStep) * CurrentAngle; // rotate the current angle up by the step angle
            }

            //pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
            //pulledBullet.SetActive(true);
           //pulledBullet.transform.rotation = Quaternion.Euler(0, 0, (zRotation * Mathf.Rad2Deg) + (spread/50));
           // pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
           // pulledBullet.transform.position = enemy.bulParent.position;
           // pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
           // pulledBullet.GetComponent<Bullet>().damage = enemy.damage;
           // Debug.Log(currentAngle);
           // float bulDirX = pulledBullet.transform.position.x + Mathf.Sin((temp * Mathf.PI)/180);
           // float bulDirY = pulledBullet.transform.position.y + Mathf.Cos((temp * Mathf.PI)/180);
           // Debug.Log("fire4 step 2");
           // Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
           // Vector2 bulDir = (bulMoveVector - pulledBullet.transform.position).normalized;

           // pulledBullet.GetComponent<Bullet>().SetMoveDirection(bulDir);

           // currentAngle += angleStep;
        //}
        Debug.Log("fire4 step 3");
    }


    public static void Fire5()
    {

        pulledBullet = GameManager.Instance.bulletPool.GetBullet(bul);
        pulledBullet.SetActive(true);
        pulledBullet.GetComponent<Bullet>().bulletDuration = enemy.howLongWillBulletLast;
        pulledBullet.transform.position = enemy.bulParent.position;
        pulledBullet.GetComponent<Bullet>().firingPattern = enemy.enemyFireingType;
        pulledBullet.GetComponent<Bullet>().damage = enemy.damage;

        float bulDirX = pulledBullet.transform.position.x + Mathf.Sin((angle + 180 * Mathf.PI) / 180f);
        float bulDirY = pulledBullet.transform.position.y + Mathf.Cos((angle + 180 * Mathf.PI) / 180f);
        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - bulletTransform.position).normalized;
        pulledBullet.GetComponent<Bullet>().SetMoveDirection(bulDir);

        angle += stepAngle;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
    
    public static void FireSummoner()//new enemy, summons minions to attack instead of actually attacks.
    {

    }
}
