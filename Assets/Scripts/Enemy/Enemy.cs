using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float viewDistance;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform raycastStartPoint;
    [SerializeField] private float coolDown;
    private Rigidbody2D rigidBody;
    private GameObject player;

    //path
    private int index = 0;
    private Transform[] path;
    private Transform currentPoint;
    private MainWall mainWall;
    private bool isPathEnded = false;
    private float attackCoolDown;
    private bool isDestroyed=false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = SingleGameEnterPoint.instance.GetPlayer();
        path = SingleGameEnterPoint.instance.GetEnemyPathManager().GetEnemyPathHolder().Waypoints();
        currentPoint = path[index];
    }

    private void Update()
    {
        attackCoolDown += Time.deltaTime;
        if (isPathEnded)
        {
            
            if(attackCoolDown >= coolDown)
            {
                Attack();
                attackCoolDown = 0;
            }
            
        }
        Move();
    }

    public void Attack()
    {
        if (mainWall == null) return;
        mainWall.AttackWall(damage);
    }

    public void Move()
    {
        Vector2 dir = (currentPoint.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.05f)
        {
            if (isPathEnded)
            {
                rigidBody.velocity = Vector2.zero;
                return;
            }
            if (index + 1 >= path.Length)
            {
                isPathEnded = true;
                currentPoint = SingleGameEnterPoint.instance.GetRandomPoint();
                mainWall = SingleGameEnterPoint.instance.GetMainWall();
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
        if (health <= 0 && !isDestroyed)
        {
            MobSpapwner.onEnemyDestroy?.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
