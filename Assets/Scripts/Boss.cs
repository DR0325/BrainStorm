using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public Transform FirePoint;
    private Transform player;
    public GameObject stress;

    public BossBar bar;

    bool facingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > gameObject.transform.position.x && facingRight == false)
        {
            Flip();
        }
        if(player.position.x < gameObject.transform.position.x && facingRight == true)
        {
            Flip();
        }

        if(stress == null)
        {
            bar.Deactivate();
            Destroy(gameObject);
        }
    }

    public void WaveAttack()
    {
        if(bullet != null && FirePoint != null)
        {
            GameObject mBullet = Instantiate(bullet, FirePoint.position, Quaternion.identity);

            EnemyProjectile bulletControl = mBullet.GetComponent<EnemyProjectile>();

            if (!facingRight)
            {
                bulletControl.moveDirection = Vector2.left;
            }
            else
            {
                mBullet.transform.Rotate(0f, 180f, 0f);
                bulletControl.moveDirection = Vector2.left;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
