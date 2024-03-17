using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IInteractible
{
    private int stoneHealth = 7;
    private bool isPossibleToGet = false;
    public void Action(Inventory inventory)
    {
        if (isPossibleToGet)
        {
            stoneHealth-=1;
            if(stoneHealth <= 0)
            {
                inventory.Stone += 1;
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
