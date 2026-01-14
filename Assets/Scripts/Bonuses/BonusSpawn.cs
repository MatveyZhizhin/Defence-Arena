using ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Bonuses
{
    public class BonusSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _bonusPrefab;
        [SerializeField] private float _spawnRate;
        [SerializeField] private Transform[] _spawnPoint;

        [SerializeField] private Chance _bonusChances;

        void Start()
        {
            StartCoroutine(SpawnBonuses());
        }

        private IEnumerator SpawnBonuses()
        {
            while (true)
            {
                var obj = Instantiate(_bonusPrefab[Randomizer.GetRandomIndexWithChance(_bonusChances.Chances)], _spawnPoint[Random.Range(0, _spawnPoint.Length)].position , Quaternion.identity);
                yield return new WaitForSeconds(_spawnRate);
            }
        }

    }
}
