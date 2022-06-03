using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;

    private GameObject player;
    [HideInInspector]
    public Vector2 moveDirection;

    public GameObject destroyEffect;
    public LayerMask isSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection != null)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
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