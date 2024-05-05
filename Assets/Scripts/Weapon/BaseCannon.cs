using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCannon : MonoBehaviour, IInteractible
{
    private GameObject cannon;


    public void Action(Inventory inventory)
    {
        Debug.Log("Fdsf");
        if (cannon != null) return;
        
        PutCannon(inventory);
    }

    private void PutCannon(Inventory inventory)
    {
        if(inventory.IronIngot >= 5)
        {
            inventory.IronIngot -= 5;
            GameObject cannonToCreate = CannonManager.main.GetCannon();
            cannon = Instantiate(cannonToCreate, transform.position, Quaternion.identity);
        }
    }
}
