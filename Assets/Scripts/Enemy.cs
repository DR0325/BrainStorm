using System;
using UnityEngine;

public class Enemy : DestructableObject
{
    public int _experienceGain;
	public float attackTime;
	//Enemy properties
	[Range(100f,1000f)]
	public float enemyPower;
    public bool followsPlayer;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    private GameObject player;

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
        
        if (_isTouchingPlayer)
        {
            _timeSinceLastDamage += Time.deltaTime;
            if (_timeSinceLastDamage > attackTime)
            {
                DamagePlayer();
            }
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