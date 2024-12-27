using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : Singleton<HealthManager>
{
    [SerializeField]
    private int MaxHealth = 100;

    [SerializeField]
    private Button RestartButton;

    private int currentHealth;

    [Header("Interface")]
    [SerializeField] UnityEngine.UI.Image Fill;
    [SerializeField] UnityEngine.UI.Text CurrentHealthText;

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.onClick.AddListener(() =>
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1;
        });

        RestartButton.gameObject.SetActive(false);
        currentHealth = MaxHealth;
        UpdateInterface();
    }

    public void IncrementMaxHealth(int health)
    {
        MaxHealth += health;
        currentHealth += health;
        UpdateInterface();
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        UpdateInterface();

        if (currentHealth <= 0) {
            RestartButton.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void RestoreHealth(int health)
    {
        currentHealth = Mathf.Min(currentHealth + health, MaxHealth);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        if(Fill != null)
            Fill.fillAmount = (float)currentHealth/ (float)MaxHealth;

        if (CurrentHealthText != null)
            CurrentHealthText.text = "Health : " + currentHealth + "/" + MaxHealth;
    }
}
