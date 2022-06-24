using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    private Transform player;
    private float distanceFromPlayer;

    private Rigidbody2D rb;
    public Animator anim;
    bool facingRight = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > gameObject.transform.position.x && facingRight == false)
        {
            Flip();
        }
        if (player.position.x < gameObject.transform.position.x && facingRight == true)
        {
            Flip();
        }
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        
        if (GetComponent<Enemy>().hitPlayer == false)
        {
            if (distanceFromPlayer < lineOfSight)
            {
                anim.SetBool("startle", true);
                rb.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                anim.SetBool("followPlayer", true);
            }
        }
        if (GetComponent<Enemy>().hitPlayer == true)
        {
            rb.position = Vector2.MoveTowards(this.transform.position, player.position, -speed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
