using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private Text WaveText;

    [SerializeField]
    private int MobsPerWaves = 5;

    private int waveCount = 0;

    void Start()
    {
        UpdateText();

        MobManager.Instance.OnAmountChange.AddListener((int mobAmount) =>
        {
            if (mobAmount <= 0)
            {
                StartNewWave();
            }
        });

        StartCoroutine(StartWithDelay(5));
    }

    IEnumerator StartWithDelay(int delay)
    {
        yield return new WaitForSeconds(delay);

        if (MobManager.Instance.MobAmount <= 0)
        {
            StartNewWave();
        }
    }

    // Update is called once per frame
    private void StartNewWave()
    {
        waveCount++;

        for(int i = 0;  i < MobsPerWaves * waveCount; ++i)
        {
            MobManager.Instance.SpawnRandomMob();
        }

        UpdateText();
    }

    void UpdateText()
    {
        WaveText.text = "Wave " + waveCount;
    }
}
