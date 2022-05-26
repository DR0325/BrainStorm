using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;

    private GameObject player;
    private Vector2 moveDirection;

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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RaycastHit2D hitInf = Physics2D.Raycast(transform.position, transform.up, distance, isSolid);
        if (hitInf.collider != null)
        {
            if (hitInf.collider.CompareTag("Player"))
            {
                hitInf.collider.GetComponent<Player>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}