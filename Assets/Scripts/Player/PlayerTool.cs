using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTool : MonoBehaviour
{
    string[] tools = { "Pickaxe", "Axe", "Sword" };
    int index = 0;
    public void ChooseTool(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            int value = NormalizeValue(context.ReadValue<float>());
            index += value;
            if (index < 0) index = tools.Length - 1;
            index %= tools.Length;
            Debug.Log(tools[index]);
        }
    }

    public string GetTool()
    {
        return tools[index];
    }

    private int NormalizeValue(float value)
    {
        if(value > 0)
        {
            return 1;
        }
        return -1;
    }
}
