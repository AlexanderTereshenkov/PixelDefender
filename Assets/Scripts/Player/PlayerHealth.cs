using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;

    public void TakeDamage(float damage)
    {

    }

    public void Heal(float hp)
    {
        health += hp;
        health = Mathf.Clamp(health, 0, 100);
    }
}
