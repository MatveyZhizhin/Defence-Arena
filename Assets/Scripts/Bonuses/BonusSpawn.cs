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

        }

        private IEnumerator SpawnBonuses()
        {
            var pos = Random.insideUnitSphere();
        }

    }
}
