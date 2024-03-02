using UnityEngine;

public class Tree : MonoBehaviour, IInteractible
{
    private int treeHealth = 5;
    public void Action(Inventory inventory)
    {
        inventory.Wood += 1;
        treeHealth--;
        Debug.Log(inventory.Wood + " wood count");
        if (treeHealth <= 0) Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        Debug.Log("This is tree");
    }

}

