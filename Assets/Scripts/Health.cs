using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void RestoreDamage(float damage)
    {
        currentHealth += damage;
        if (currentHealth>maxHealth)
        {
            currentHealth= maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
