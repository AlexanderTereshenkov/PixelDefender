using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerTool : MonoBehaviour, IPausablePlayer
{

    [SerializeField] private Sprite[] toolIcons;

    private string[] tools = { "Pickaxe", "Axe", "Sword" };
    private int index = 0;
    private bool isPaused;
    private Image toolIconPlace;

    private void Start()
    {
        toolIconPlace = SingleGameEnterPoint.instance.GetPlayerUI().GetIconPlace();
        toolIconPlace.sprite = toolIcons[index];
    }
    public void ChooseTool(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            return;
        }
        if (context.performed)
        {
            int value = NormalizeValue(context.ReadValue<float>());
            index += value;
            if (index < 0) index = tools.Length - 1;
            index %= tools.Length;
            toolIconPlace.sprite = toolIcons[index];
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

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }
}
