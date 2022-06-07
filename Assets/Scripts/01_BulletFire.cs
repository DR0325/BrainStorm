using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Fire()
    {
        Bullet bul = GameManager.Instance.bulletPool.GetBullet(0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
