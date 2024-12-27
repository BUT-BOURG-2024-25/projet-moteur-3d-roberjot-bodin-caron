using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int Xp = 10;

    [SerializeField]
    private Drop Drop;

    [SerializeField]
    [Range(0, 1)]
    private float DropLuck;

    [SerializeField]
    private float MaxHealth = 100f;
    private float currentHealth;

    public readonly UnityEvent OnDie = new();

    public Health()
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
        System.Random randomizr = new System.Random();
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 offset = Vector3.down*0.8f;

        if(randomizr.NextDouble() <= DropLuck)
        {
            Instantiate(Drop, transform.position + offset, transform.rotation);
        }

        OnDie.Invoke();
        XPManager.Instance.IncrementXP(Xp);
        Destroy(gameObject);
    }
}
