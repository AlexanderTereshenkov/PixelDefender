using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float maxInteractionRange;

    private void Update()
    {
        Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    public void LeftMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, maxInteractionRange);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractible interactible))
                {
                    interactible.Action(inventory);
                }
            }

        }
    }
}
