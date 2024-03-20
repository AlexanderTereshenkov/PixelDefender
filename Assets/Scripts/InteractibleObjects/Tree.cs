
public class Tree : BreakableObject, IInteractible
{
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {
            inventory.Wood += 1;
            health--;
            if (health <= 0) Destroy(gameObject);
        }
    }
}

