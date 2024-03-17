using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour, IInteractible
{
    private int ironHealth = 10;
    private bool isPossibleToGet = false;
    public void Action(Inventory inventory)
    {
        if (isPossibleToGet)
        {   
            
            ironHealth -= Random.Range(1, 4);
            if (ironHealth <= 0)
            {
                inventory.Iron += 1;
                Destroy(gameObject);
            }
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
