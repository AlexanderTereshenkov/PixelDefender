using UnityEngine;

public class BaseCannon : MonoBehaviour, IInteractible
{

    [SerializeField] private int ironIngotPrice;
    [SerializeField] private int woodPrice;

    private GameObject cannon;

    public void Action(Inventory inventory)
    {
        Debug.Log("Fdsf");
        if (cannon != null) return;
        
        PutCannon(inventory);
    }

    private void PutCannon(Inventory inventory)
    {
        if(inventory.IronIngot >= ironIngotPrice && inventory.Wood >= woodPrice)
        {
            inventory.IronIngot -= ironIngotPrice;
            inventory.Wood -= woodPrice;
            GameObject cannonToCreate = CannonManager.main.GetCannon();
            cannon = Instantiate(cannonToCreate, transform.position, Quaternion.identity);
        }
    }
}
