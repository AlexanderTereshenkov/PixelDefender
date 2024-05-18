using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
    private Transform target;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        target.GetComponent<Enemy>().CancelTarget += CancelTarget;
    }

    private void OnDisable()
    {
        target.GetComponent<Enemy>().CancelTarget -= CancelTarget;
    }

    void FixedUpdate()
    {
        if (!target) return;
        if (target.IsDestroyed())
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

    public void CancelTarget()
    {
        Destroy(gameObject);
    }
}
