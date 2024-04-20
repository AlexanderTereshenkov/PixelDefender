using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform cannonRotationPoint;
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float timeToShoot;
    private float tempSeconds;
    private Transform target;


    private void Update()
    {       
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            tempSeconds += Time.deltaTime;
            if (tempSeconds > timeToShoot)
            {
                Shoot();
                tempSeconds = 0;
            }
        }

    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
            transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
            Debug.Log("цель найдена");
        }
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,
            target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        cannonRotationPoint.rotation = Quaternion.RotateTowards(cannonRotationPoint.rotation, 
            targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    void Shoot()
    {   
        GameObject bulletObj = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
}
