using System;
using UnityEngine;

public class Enemy : DestructableObject
{
    public int _experienceGain;
	public float attackTime;
    public bool doesEnemyMove;
    //Enemy properties
    public float moveSpeed;
    [Range(100f, 1000f)]
	public float enemyPower;
    public bool showEnemyLineOfSight;
    public bool showEnemyAttackRange;
    public float enemyAttackRange;
    public float enemyLineOfSight;
    public float enemyFireRate;
    private float nextFireTime;
    public bool followsPlayer;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    private GameObject player;
    public GameObject bullet;
    public GameObject bulletParent;

    public CapsuleCollider2D collider;
    
	private void Awake()
    {
        DeathAction = () =>
        {
            --GameManager.Instance.enemiesCount;
            GameManager.Instance.QtyExperience += _experienceGain;
        };
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
     
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        //enemy moving towards player
        if (doesEnemyMove == true)
        {
           
            if (distanceFromPlayer < enemyLineOfSight && distanceFromPlayer > enemyAttackRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }

        if(distanceFromPlayer<=enemyAttackRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + enemyFireRate;
        }

            if (_isTouchingPlayer)
        {
            _timeSinceLastDamage += Time.deltaTime;
            if (_timeSinceLastDamage > attackTime)
            {
                DamagePlayer();
            }
        }
    }

    //Shows enemy Line of sight and attack range
    private void OnDrawGizmosSelected()
    {
        if (showEnemyLineOfSight == true)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, enemyLineOfSight);
        }
        if (showEnemyAttackRange == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, enemyAttackRange);
        }
    }

    private void DamagePlayer()
    {
        Player p = player.GetComponent<Player>();
        p.Health -= enemyPower * 0.01f;
        bool left = transform.position.x > p.transform.position.x;
        p.rb.AddForce(new Vector2((left ? -enemyPower : enemyPower) * 3.0f, 0.0f));
        _timeSinceLastDamage = 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _isTouchingPlayer = true;
            DamagePlayer();
            _timeSinceLastDamage = 0.0f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) _isTouchingPlayer = false;
    }
}