using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
