using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour, IPausablePlayer
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float maxInteractionRange;
    [SerializeField] private LayerMask interactibleLayer;

    private PlayerTool playerTool;
    private GameplayHandler gameplayHandler;
    private bool isPaused = false;

    private void Start()
    {
        playerTool = GetComponent<PlayerTool>();
        gameplayHandler = SingleGameEnterPoint.instance.GetGameplayHandler();
    }

    public void LeftMouseClick(InputAction.CallbackContext context)
    {
        if (isPaused) return;
        if(playerTool.GetTool() != "Sword")
        {
            if (context.performed)
            {
                var hit = GetRaycastHit();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetComponent(out IBreakable breakable))
                    {
                        breakable.Action(inventory, playerTool.GetTool());
                    }
                }
            }
        }
    }

    public void InteractibleobjectsAction(InputAction.CallbackContext context)
    {
        if (isPaused) return;
        if (context.performed)
        {
            var hit = GetRaycastHit();
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractible interactible))
                {
                    interactible.Action(inventory);
                }
            }
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(gameplayHandler != null)
            {
                if (isPaused)
                {
                    gameplayHandler.Resume();
                    isPaused = false;
                }
                else
                {
                    gameplayHandler.Pause();
                    isPaused = true;
                }
            }

        }
    }

    private RaycastHit2D GetRaycastHit()
    {
        Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, maxInteractionRange, interactibleLayer);

        return hit;
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
