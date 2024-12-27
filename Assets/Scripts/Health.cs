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
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Vector3 diffPos = Vector3.down * renderer.bounds.size.y / 2;

        if(randomizr.NextDouble() <= DropLuck)
        {
            Instantiate(Drop, transform.position + diffPos, transform.rotation);
        }

        OnDie.Invoke();
        XPManager.Instance.IncrementXP(Xp);
        Destroy(gameObject);
    }
}
