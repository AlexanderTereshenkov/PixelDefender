
public class Stone : BreakableObject, IInteractible
{
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {
            health-=1;
            if(health <= 0)
            {
                inventory.Stone += 1;
                Destroy(gameObject);
            }
        }
    }
}
