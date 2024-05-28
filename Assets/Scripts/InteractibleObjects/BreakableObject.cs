using UnityEngine;

public abstract class BreakableObject : Sounds
{
    [SerializeField] internal string usableTool;
    [SerializeField] internal float health;
    [SerializeField] internal GameObject particles;
    [SerializeField] internal Transform particlesTransform;

    internal bool isPossibleToGet = false;

    internal float maxHealth;

    private void Start()
    {
        health = Random.Range((int)health, (int)health + 10);
        maxHealth = health;
    }

    private void OnMouseEnter()
    {
        isPossibleToGet = true;
    }

    private void OnMouseExit()
    {
        isPossibleToGet = false;
    }
}
