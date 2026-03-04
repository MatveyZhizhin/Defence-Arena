using Assets.Scripts.Enemy;
using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using YG;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private List<_Enemy> allEnemies;
    [SerializeField] private int enemiesAmount;

    private int wavesCount;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI wavesCountText;

    private SpawnManager spawnManager;
    private UpgradesButtonsManager upgradesButtonsManager;
    private Record record;

    public event Action WaveEnded;

    [SerializeField] private float startSpeedMultiplier;
    [SerializeField] private int startHealthMultiplier;

    private float speedMultiplier = 1;
    private int healthMultiplier = 1;

    private void Awake()
    {
        TryGetComponent(out spawnManager);
        TryGetComponent(out upgradesButtonsManager);
        record = FindObjectOfType<Record>();
    }

    private void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        YandexGame.FullscreenShow();

        upgradesButtonsManager.OnUpgrade -= StartWave;
        
        wavesCount++;
        wavesCountText.SetText(wavesCount.ToString());
        if (wavesCount % 2 == 0)
        {
            if (allEnemies != null)
                spawnManager.AddEnemy(ref allEnemies);
            speedMultiplier *=  startSpeedMultiplier;
        }
        
        if(wavesCount % 3 == 0)
        {
            healthMultiplier *= startHealthMultiplier;
        }

        StartCoroutine(spawnManager.Spawn(enemiesAmount, healthMultiplier, speedMultiplier));
    }

    private void StopWave()
    {
        WaveEnded?.Invoke();
        enemiesAmount *= 2;
        record.ChangeRecord(wavesCount);       
        upgradesButtonsManager.EnableButtons();
        upgradesButtonsManager.OnUpgrade += StartWave;
    }

    private void OnEnable()
    {
        spawnManager.EnemiesDied += StopWave;
    }

    private void OnDisable()
    {
        spawnManager.EnemiesDied -= StopWave;
    }
}
