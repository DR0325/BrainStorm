using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Patrol : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool _Patrol;
    private bool mustFlip;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        _Patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_Patrol == true)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
       if(_Patrol == true)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        } 
    }

    void Patrol()
    {
        if(mustFlip == true || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.deltaTime, rb.velocity.y);

    }
    
    void Flip()
    {
        _Patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        _Patrol = true;
    }
}
