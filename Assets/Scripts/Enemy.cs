using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int _experienceGain;
    public float attackTime;
    public float health;
    public float damage;

    public SpriteRenderer sprite;
    public float flashTime;

    //Enemy properties
    public bool followsPlayer;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    public GameObject bulletParent;
    public int enemyScoreValue;


    public Collider2D hurtBox;
    private GameObject player;

    private void Awake()
    {

    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {    
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.score += enemyScoreValue;
        }
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
}