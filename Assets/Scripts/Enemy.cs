using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy enemyInstance;
    public float health;
    public float damage;
    public int _experienceGain;

    private float dmgMultip;
    private float healthMultip;
    public int enemyScoreValue;
    public SpriteRenderer sprite;
    public float flashTime;

    [Header("Enemy Firing Information")]
    public int enemyFireingType;
    public float fireRate;
    public float bulletSpeed;
    //public float pauseRate; //pause delay between shots. currently not implimented TODO
    [HideInInspector] public float nextFire;
    public float firingRange;
    public GameObject bulletParent;
    public GameObject bulletType;
    [Header("Type 3 & 4 Firing Information")]
    public float stepAngle_3;// for bullet type 3
    public int numberOfBullets_4;// for bullet type 4 use
    public float startAngle_4; //for bullet type 4 use
    public float endAngle_4; // for bullet type 4 use

    [Header("Enemy Moving Information")]
    public bool followsPlayer;
    public float moveSpeed;
    public float lineOfSight;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    public float howLongWillBulletLast;
    //public int enemyMovementType; //Currently not implimented TODO






    public Collider2D hurtBox;
    [HideInInspector] public Transform bulParent;
    
    [HideInInspector] public GameObject player;
    [HideInInspector] public float distanceFromPlayer;
    [Header("Draw Information")]
    public bool draw;//for draw gizmos

    //private void Awake()
    //{
   
    //}

    private void Start()
    {
        enemyInstance = this;
        nextFire = fireRate;
        dmgMultip = StateNameController.damageMultiplier;
        healthMultip = StateNameController.healthMultiplier;
        player = GameObject.FindWithTag("Player");
        health *= healthMultip;
        damage *= dmgMultip;
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
        if (draw)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, lineOfSight);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, firingRange);
        }
    }
}