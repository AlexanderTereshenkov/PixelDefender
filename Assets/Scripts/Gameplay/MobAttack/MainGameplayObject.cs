using System;
using UnityEngine;

public class MainGameplayObject : BreakableObject
{
    private bool isBroken = false;

    public event Action OnWallBroken;
    public event Action OnValueChanged;

    public void AttackWall(float damage)
    {
        if (isBroken) return;
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnValueChanged?.Invoke();
        if(health <= 0)
        {
            OnWallBroken?.Invoke();
            isBroken = true;
        }
    }

    public string GetInfo()
    {
        return health.ToString() + "/" + maxHealth.ToString();
    }
}
