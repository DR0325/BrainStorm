using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy enemyInstance;
    public int _experienceGain;
   // public float attackTime;
    public float health;
    public float damage;

    public SpriteRenderer sprite;
    public float flashTime;

    //Enemy properties
    public float fireRate;
    public float howLongWillBulletLast;
    public float pauseRate; //pause delay between shots.
    public float nextFire;
    public bool followsPlayer;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    public GameObject bulletParent;
    public GameObject bulletType;
    public int enemyScoreValue;
    public float lineOfSight;
    public float firingRange;
    public float stepAngle; 
    public int  enemyFireingType;
    public int  enemyMovementType;
    public float moveSpeed;
    public float bulletSpeed;
    public int numberOfBullets;// for bullet type 4 use
    public float startAngle; //for bullet type 4 use
    public float endAngle; // for bullet type 4 use
    public Transform bulParent;
    public Collider2D hurtBox;
    public GameObject player;
    public float distanceFromPlayer;

    private void Awake()
    {
   
    }

    private void Start()
    {
        enemyInstance = this;
        nextFire = fireRate;
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
   
       distanceFromPlayer  = Vector2.Distance(player.transform.position, transform.position);
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.score += enemyScoreValue;
        }
        else
        {
            EnemyController.EnemyAction(this.gameObject);
        }
        nextFire -= Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ouch");
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        FlashStart();
    }

    void FlashStart()
    {
        sprite.color = Color.red;
        Invoke("FlashStop", flashTime);
    }
    void FlashStop()
    {
        sprite.color = Color.white;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }
}