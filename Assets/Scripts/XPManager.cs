using UnityEngine;

public class XPManager : Singleton<XPManager>
{
    private int totalExperience;

    [Header("Interface")]
    [SerializeField] UnityEngine.UI.Image ExperienceFill;

    void Start()
    {
        UpdateInterface();
    }

    public void IncrementXP(int amount)
    {
        int lastLevel = this.GetLevel();
        totalExperience += amount;

        if (lastLevel != this.GetLevel())
        {
            StatsManager.Instance?.StartUpgrade(); 
        }

        UpdateInterface();
    }

    void UpdateInterface()
    {
        int currentLevel = this.GetLevel();
        int currentLevelExperience = this.GetXpForLevel(currentLevel);
        int nextLevelsExperience = this.GetXpForLevel(currentLevel + 1);
        print(currentLevel);
        print(currentLevelExperience);
        print(totalExperience);
        print(nextLevelsExperience);
        if (ExperienceFill != null)
        {
            float fillValue = (float)(totalExperience - currentLevelExperience)
                            / (float)(nextLevelsExperience - currentLevelExperience);
            ExperienceFill.fillAmount = fillValue;
        }
        else
        {
            print("ExperienceFill n'est pas assigné !");
        }
    }

    int GetLevel()
    {
        int level = 0;
        int currentXp = totalExperience;

        while (currentXp >= this.GetXpForLevel(level + 1))
        {
            level++;
        }

        return level;
    }

    int GetXpForLevel(int level)
    {
        return (int)(20 * Mathf.Pow(level, 2));
    }
}
