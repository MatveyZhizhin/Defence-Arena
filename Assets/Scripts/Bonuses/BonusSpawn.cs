using System.Collections;
using UnityEngine;

namespace Bonuses
{
    public class BonusSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _bonusPrefab;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _radius;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnBonuses());
        }

        private IEnumerator SpawnBonuses()
        {
            while (true)
            {
                var pos = Random.insideUnitSphere * _radius;
                var obj = Instantiate(_bonusPrefab[Random.Range(0, _bonusPrefab.Length)], pos, Quaternion.identity);

                yield return new WaitForSeconds(_spawnRate);
            }
        }

    }
}
