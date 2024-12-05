using UnityEngine;

public class XPManager : Singleton<XPManager>
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;

    [Header("Interface")]
    [SerializeField] UnityEngine.UI.Image experienceFill;

    void Start()
    {
        UpdateInterface();
    }

    public void IncrementXP(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        int nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        if (totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateInterface();

            // Start level up sequence... Possibly vfx?
        }
    }

    void UpdateInterface()
    {
        int previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        int nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);

        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        experienceFill.fillAmount = (float)start / (float)end;
    }
}