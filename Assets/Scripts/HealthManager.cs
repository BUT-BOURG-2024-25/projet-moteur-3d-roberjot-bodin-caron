using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    [SerializeField]
    private int MaxHealth = 100;

    private int currentHealth;

    [Header("Interface")]
    [SerializeField] UnityEngine.UI.Image Fill;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        UpdateInterface();
    }


    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        UpdateInterface();
    }

    public void RestoreHealth(int health)
    {
        currentHealth = Mathf.Min(currentHealth + health, MaxHealth);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        Fill.fillAmount = (float)currentHealth/ (float)MaxHealth;
    }
}
