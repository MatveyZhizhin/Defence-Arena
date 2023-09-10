using Assets.Scripts.Managers;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private int startTimeBtwWaves;
    private int timeBtwWaves;

    private SpawnManager spawnManager;
    private UpgradesButtonsManager upgradesButtonsManager;

    private void Awake()
    {
        TryGetComponent(out spawnManager);
        TryGetComponent(out upgradesButtonsManager);
    }

    private void Start()
    {
        timeBtwWaves = startTimeBtwWaves;
        StartWave();
    }

    private void StartWave()
    {
        
    }
}
