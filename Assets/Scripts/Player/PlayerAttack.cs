using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageRadius;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float maxInteractionRange;
    private Animator animator;
    private PlayerTool playerTool;
    private float coolDownTimeCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTool = GetComponent<PlayerTool>();
        coolDownTimeCounter = attackCoolDown;
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
                var hit = GetRaycastHit(maxInteractionRange);                        
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

    private RaycastHit2D GetRaycastHit(float range = 30f)
    {
        Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, range, enemyMask);

        return hit;
    }
}
