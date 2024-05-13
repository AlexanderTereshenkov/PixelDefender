using System;

public class MainGameplayObject : BreakableObject
{
    private bool isBroken = false;

    public event Action OnWallBroken;

    public void AttackWall(float damage)
    {
        if (isBroken) return;
        health -= damage;
        if(health <= 0)
        {
            OnWallBroken?.Invoke();
            isBroken = true;
        }
    }
}
