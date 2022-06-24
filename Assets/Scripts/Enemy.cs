using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    public bool hitPlayer = false;
    public int _experienceGain;
    public float attackTime;
    public float health;
    public float damage;

    private float dmgMultip;
    private float healthMultip;

    public SpriteRenderer sprite;
    public Animator anim;
    public float flashTime;

    //Enemy properties
    public bool followsPlayer;
    private bool _isTouchingPlayer;
    private float _timeSinceLastDamage;
    public GameObject bulletParent;
    public int enemyScoreValue;
    public GameObject deathParticles;

    public Collider2D hurtBox;
    private GameObject player;

    private void Awake()
    {

    }

    private void Start()
    {
        dmgMultip = StateNameController.damageMultiplier;
        healthMultip = StateNameController.healthMultiplier;
        player = GameObject.FindWithTag("Player");
        health *= healthMultip;
        damage *= dmgMultip;
    }

    private void Update()
    {
        if (anim != null && anim.GetBool("gotHit") == true)
        {
            anim.SetBool("gotHit", false);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject go = Instantiate(deathParticles) as GameObject;
            go.transform.position = transform.position;
            GameManager.Instance.score += enemyScoreValue;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           // StartCoroutine(player.GetComponent<Player>().Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(damage);
            hitPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        hitPlayer = false;
    }
    

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (anim != null)
        {
            anim.SetBool("gotHit", true);
        }
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