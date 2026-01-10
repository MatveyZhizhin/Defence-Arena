using System.Collections;
using UnityEngine;

namespace Bonuses
{
    public class BonusSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _bonusPrefab;
        [SerializeField] private float _spawnRate;
        [SerializeField] private Transform[] _spawnPoint;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnBonuses());
        }

        private IEnumerator SpawnBonuses()
        {
            while (true)
            {
                var obj = Instantiate(_bonusPrefab[Random.Range(0, _bonusPrefab.Length)], _spawnPoint[Random.Range(0, _spawnPoint.Length)].position , Quaternion.identity);
                yield return new WaitForSeconds(_spawnRate);
            }
        }

    }
}
