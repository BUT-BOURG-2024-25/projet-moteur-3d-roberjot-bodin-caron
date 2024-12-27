using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : Singleton<StatsManager>
{
    public float DamageBoost = 0;

    [SerializeField]
    private Image UpgradePanel;

    [SerializeField]
    private Button DamageUpgradeButton;

    [SerializeField]
    private Button HealthUpgradeButton;

    private bool upgrading = false;

    void Start()
    {
        DamageUpgradeButton.onClick.AddListener(() =>
        {
            if (!upgrading) return;
            DamageBoost += 10f;
            EndUpgrade();
        });
        HealthUpgradeButton.onClick.AddListener(() =>
        {
            if (!upgrading) return;
            HealthManager.Instance.IncrementMaxHealth(20);
            EndUpgrade();
        });

        EndUpgrade();
    }

    public void StartUpgrade()
    {
        if (upgrading) return;
        upgrading = true;
        Time.timeScale = 0;

        UpgradePanel.gameObject.SetActive(true);
    }

    private void EndUpgrade()
    {
        upgrading = false;
        Time.timeScale = 1;

        UpgradePanel.gameObject.SetActive(false);
    }
}
