using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

public static BulletPool bulletPoolInstanse;

    [SerializeField]
    private GameObject[] pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    //private void Awake()
    //{
    //    BulletPoolInstanse = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        bulletPoolInstanse = this;
        bullets = new List<GameObject>();   
    }

    public GameObject GetBullet(GameObject bulletToFire)
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count;i++)
            {
                if(!bullets[i].gameObject.activeInHierarchy && bullets[i].tag == bulletToFire.tag)
                {
                    return bullets[i];
                }
            }
            
        }
        if(notEnoughBulletsInPool)
        {

           GameObject bul = Instantiate(bulletToFire);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
