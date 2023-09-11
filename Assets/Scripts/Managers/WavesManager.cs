using Assets.Scripts.Enemy;
using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private _Enemy[] allEnemies;
    [SerializeField] private float startTimeBtwWaves;

    private float timeBtwWaves;
    private int wavesCount;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI wavesCountText;

    private SpawnManager spawnManager;
    private UpgradesButtonsManager upgradesButtonsManager;

    private bool IsWaveStopped;

    private void Awake()
    {
        TryGetComponent(out spawnManager);
        TryGetComponent(out upgradesButtonsManager);
    }

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        DicreaseTimer();
    }

    private void StartWave()
    {
        timeBtwWaves = startTimeBtwWaves;
        IsWaveStopped = false;
        spawnManager.SpawnRate -= 0.05f; 
        upgradesButtonsManager.OnUpgrade -= StartWave;
        StartCoroutine(spawnManager.Spawn());
        wavesCount++;
        wavesCountText.SetText($"Волна: {wavesCount}");
        if (wavesCount % 5 == 0)
        {
            spawnManager.AddEnemy(allEnemies);
        }
    }

    private void StopWave()
    {
        StopAllCoroutines();
        spawnManager.DeleteEnemies();
        upgradesButtonsManager.EnableButtons();
        IsWaveStopped = true;
        upgradesButtonsManager.OnUpgrade += StartWave;
    }

    private void DicreaseTimer()
    {
        if (timeBtwWaves <= 0)
        { 
            if (!IsWaveStopped)
            {
                StopWave();
            }         
        }
        else
        {
            timeBtwWaves -= Time.deltaTime;
            timerText.SetText(Mathf.Round(timeBtwWaves).ToString());
        }
    }
}
