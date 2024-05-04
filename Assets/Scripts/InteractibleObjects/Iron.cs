using UnityEngine;

public class Iron : BreakableObject, IInteractible
{
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {   
            health -= Random.Range(1, 4);
            if (health <= 0)
            {
                inventory.Iron += 1;
                Destroy(gameObject);
            }
        }
    }
}
