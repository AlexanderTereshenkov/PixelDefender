
public class Tree : BreakableObject, IBreakable
{
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {
            inventory.Wood += 1;
            health--;
            Instantiate(particles, particlesTransform);
            if (health <= 0) Destroy(gameObject);
        }
    }
}

