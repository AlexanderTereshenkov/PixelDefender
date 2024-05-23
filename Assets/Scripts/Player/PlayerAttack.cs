using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageRadius;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float maxInteractionRange;
    [SerializeField] private Texture2D cursorDefault;
    [SerializeField] private Texture2D cursorChanged;
    private Animator animator;
    private PlayerTool playerTool;
    private float coolDownTimeCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTool = GetComponent<PlayerTool>();
        coolDownTimeCounter = attackCoolDown;
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        coolDownTimeCounter += Time.deltaTime;
          
    }


    public void Attack(InputAction.CallbackContext context)
    {
        if(playerTool.GetTool() == "Sword" && coolDownTimeCounter >= attackCoolDown)
        {
            if (context.performed)
            {
                animator.SetTrigger("Attack");
                var hit = GetRaycastHit();                        
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                    {
                        enemy.TakeDamage(damage);
                    }
                }
                
                coolDownTimeCounter = 0;
            }

        }  
    }

    private RaycastHit2D GetRaycastHit()
    {
        Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, maxInteractionRange, enemyMask);

        return hit;
    }
}
