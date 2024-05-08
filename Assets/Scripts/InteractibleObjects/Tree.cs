using UnityEngine;

public class Tree : BreakableObject, IBreakable
{

    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {
            inventory.Wood += Random.Range(1, 6);
            health--;
            Instantiate(particles, particlesTransform);
            if (health <= 0) Destroy(gameObject);
        }
    }

}

