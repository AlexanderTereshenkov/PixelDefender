using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTool : MonoBehaviour
{
    string[] tools = { "Pickaxe", "Axe" };
    int index = 0;
    public void EButtonClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            index++;
            Debug.Log(tools[index % tools.Length]);
        }
    }

    public string GetTool()
    {
        return tools[index % tools.Length];
    }
}
