using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    private Transform target;
    private Enemy currentEnemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        currentEnemy = target.GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if (!target) return;
        if (currentEnemy.IsObjectDestroyed())
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
