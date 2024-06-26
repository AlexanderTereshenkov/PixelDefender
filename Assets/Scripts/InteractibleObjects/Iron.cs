using UnityEngine;

public class Iron : BreakableObject, IBreakable
{
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {   
            health -= Random.Range(1, 4);
            PlaySound(sounds[0], destroyed: health <= 0);
            Instantiate(particles, particlesTransform);
            if (health <= 0)
            {
                inventory.Iron += Random.Range(1, 4);
                Destroy(gameObject);
            }
        }
    }
}
