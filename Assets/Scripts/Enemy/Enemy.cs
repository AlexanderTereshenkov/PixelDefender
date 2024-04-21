using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float viewDistance;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform raycastStartPoint;
    private Rigidbody2D rigidBody;
    private GameObject player;


    //path
    private int index = 0;
    private Transform[] path;
    private Transform currentPoint;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = SingleGameEnterPoint.instance.GetPlayer();
        path = SingleGameEnterPoint.instance.GetEnemyPathManager().GetEnemyPathHolder().Waypoints();
        currentPoint = path[index];
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
        Vector2 dir = (currentPoint.position - transform.position).normalized;
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.05f)
        {
            if(index + 1 >= path.Length)
            {
                rigidBody.velocity = Vector2.zero;
                return;
            }
            index++;
            currentPoint = path[index];
        }
        rigidBody.velocity = dir * speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            MobSpapwner.onEnemyDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

}
