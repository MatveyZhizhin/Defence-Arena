using Assets.Scripts.Enemy;
using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;
using Assets.Scripts.Player;
using System;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private _Enemy[] allEnemies;
    [SerializeField] private int enemiesAmount;

    private int wavesCount;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI wavesCountText;

    private SpawnManager spawnManager;
    private UpgradesButtonsManager upgradesButtonsManager;
    private Record record;

    public event Action WaveEnded;

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
        upgradesButtonsManager.OnUpgrade -= StartWave;
        StartCoroutine(spawnManager.Spawn(enemiesAmount));
        wavesCount++;
        wavesCountText.SetText(wavesCount.ToString());
        if (wavesCount % 5 == 0)
        {
            spawnManager.AddEnemy(allEnemies);
        }
    }

    private void StopWave()
    {
        WaveEnded?.Invoke();
        record.ChangeRecord(wavesCount);
        spawnManager.AdditionalHealth += 1;
        spawnManager.AdditionalSpeed += 0.5f;
        enemiesAmount += 5;
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
