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

    [SerializeField] private float speedMultiplier;
    [SerializeField] private int healthMultiplier;

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
        
        wavesCount++;
        wavesCountText.SetText(wavesCount.ToString());
        if (wavesCount % 2 == 0)
        {
            spawnManager.AddEnemy(allEnemies);
            StartCoroutine(spawnManager.Spawn(enemiesAmount,1,speedMultiplier));
        }
        else if(wavesCount % 3 == 0)
        {
            StartCoroutine(spawnManager.Spawn(enemiesAmount, healthMultiplier, 1));
        }
        else
        {
            StartCoroutine(spawnManager.Spawn(enemiesAmount));
        }

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
