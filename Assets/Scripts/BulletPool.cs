using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

//public static BulletPool BulletPoolInstanse;

    [SerializeField]
    private Bullet[] pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<Bullet> bullets;

    //private void Awake()
    //{
    //    BulletPoolInstanse = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<Bullet>();   
    }

    public Bullet GetBullet(int whatBullet)
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count;i++)
            {
                if(!bullets[i].gameObject.activeInHierarchy && bullets[i].tag == pooledBullet[whatBullet].tag)
                {
                    return bullets[i];
                }
            }
        }
        if(notEnoughBulletsInPool)
        {
            Bullet bul = Instantiate(pooledBullet[whatBullet]);
            bul.gameObject.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
