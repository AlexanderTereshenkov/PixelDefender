using UnityEngine;

public class Tree : MonoBehaviour, IInteractible
{
    //maybe create another abstract class InteractibleObject and do class inheritance
    [SerializeField] private string usableTool;
    private int treeHealth = 5;
    private bool isPossibleToGet = false;
    public void Action(Inventory inventory, string tool)
    {
        if (isPossibleToGet && tool.Equals(usableTool))
        {
            inventory.Wood += 1;
            treeHealth--;
            if (treeHealth <= 0) Destroy(gameObject);
        }
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

