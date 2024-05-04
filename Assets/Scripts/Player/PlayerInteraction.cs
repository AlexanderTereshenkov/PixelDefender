using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float maxInteractionRange;
    [SerializeField] private LayerMask interactibleLayer;

    private PlayerTool playerTool;
    private PlayerAttack playerAttack;

    private void Start()
    {
        playerTool = GetComponent<PlayerTool>();
    }


    public void LeftMouseClick(InputAction.CallbackContext context)
    {
        if(playerTool.GetTool() != "Sword")
        {
            if (context.performed)
            {
                var hit = GetRaycastHit();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetComponent(out IInteractible interactible))
                    {
                        interactible.Action(inventory, playerTool.GetTool());
                    }
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
}
