using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : Sounds, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float viewDistance;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform raycastStartPoint;
    [SerializeField] private float coolDown;
    [SerializeField] GameObject coin;
    [SerializeField] private GameObject bloodParticles;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private GameObject player;

    //path
    private int index = 0;
    private Transform[] path;
    private Transform currentPoint;
    private MainGameplayObject mainWall;
    private bool isPathEnded = false;
    private float attackCoolDown;
    private bool isDestroyed=false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = SingleGameEnterPoint.instance.GetPlayer();
        path = SingleGameEnterPoint.instance.GetEnemyPathManager().GetEnemyPathHolder().Waypoints();
        currentPoint = path[index]; 
    }

    private void Update()
    {
        if (isDestroyed) return;
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
        animator.SetTrigger("Attack");
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
        animator.SetFloat("Speed", rigidBody.velocity.magnitude);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        PlaySound(sounds[0], destroyed: health <= 0, volume:0.35f);
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        if (health <= 0 && !isDestroyed)
        {
            MobSpapwner.onEnemyDestroy?.Invoke();
            gameObject.layer = 0;
            isDestroyed = true;
            animator.SetTrigger("Death");
            StartCoroutine(DeadAnimation());
            rigidBody.isKinematic = true;  
            rigidBody.velocity = Vector2.zero;
            boxCollider.enabled = false;
        }
    }

    private IEnumerator DeadAnimation()
    {
        yield return new WaitForSeconds(3f);

        float tempTime = 0;

        Color color = spriteRenderer.color;

        while(spriteRenderer.color.a > 0)
        {
            tempTime += Time.deltaTime;
            float tempColor = Mathf.Lerp(1, 0, tempTime / 1f);
            color.a = tempColor;
            spriteRenderer.color = color;
            yield return null;
        }
        Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public bool IsObjectDestroyed() => isDestroyed;

}
