using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float MaxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void RestoreHealth(float health)
    {
        currentHealth = Math.Min(currentHealth + health, MaxHealth);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
