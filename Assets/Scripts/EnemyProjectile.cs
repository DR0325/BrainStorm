using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;

    private GameObject player;
    private bool isTriggered = false;
    [HideInInspector]
    public Vector2 moveDirection;

    public GameObject destroyEffect;
    public LayerMask isSolid;

    // Start is called before the first frame update
    void Start()
    {
        damage *= StateNameController.damageMultiplier;
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && isTriggered == false)
        {
            isTriggered = true;
            collision.GetComponent<Player>().TakeDamage(damage);
            DestroyProjectile();
        }
        if (collision.IsTouchingLayers(isSolid))
            DestroyProjectile();
        
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}