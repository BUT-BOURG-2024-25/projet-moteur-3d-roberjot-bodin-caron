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
            // level up
        }

        UpdateInterface();
    }

    void UpdateInterface()
    {

        int currentLevel = this.GetLevel();
        int previousLevelsExperience = this.GetXpForLevel(currentLevel);
        int nextLevelsExperience = this.GetXpForLevel(currentLevel + 1);

        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        if (ExperienceFill != null)
        {
            ExperienceFill.fillAmount = (float)start / (float)end;
        }
    }

    int GetLevel()
    {
        return Mathf.FloorToInt((totalExperience - 50) / 20);
    }

    int GetXpForLevel(int level)
    {
        return 50 + 20 * level;
    }
}