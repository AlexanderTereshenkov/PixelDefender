using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageRadius;
    [SerializeField] private LayerMask enemyMask;
    private Animator animator;
    private PlayerTool playerTool;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTool = GetComponent<PlayerTool>();
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if(playerTool.GetTool() == "Sword")
        {
            if (context.performed)
            {
                animator.SetTrigger("Attack");
                var enemies = FindEnemies();
                foreach (Collider2D enemy in enemies)
                {
                    if (enemy.TryGetComponent(out IEnemy e))
                    {
                        e.TakeDamage(damage);
                    }
                }
            }

        }  
    }

    private Collider2D[] FindEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, damageRadius, enemyMask);
    }
}
