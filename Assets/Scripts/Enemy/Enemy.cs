using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    private Rigidbody2D rigidBody;
    private GameObject player;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = SingleGameEnterPoint.instance.GetPlayer();
    }

    private void Update()
    {
        Move();
    }

    public void Attack()
    {

    }

    public void Move()
    {
        Vector2 dir = player.transform.position - transform.position;
        dir.Normalize();
        rigidBody.velocity = dir * speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    private void CastRay()
    {

    }
}
