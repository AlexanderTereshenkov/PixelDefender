using UnityEngine;

public class MainWall : BreakableObject
{

    public void AttackWall(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
