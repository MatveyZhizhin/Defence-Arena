using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private List<_Enemy> currentEnemies;
        private List<_Enemy> spawnedEnemies = new List<_Enemy>();
        [SerializeField] private float spawnRate;

        public void AddEnemy(_Enemy enemy)
        {
            currentEnemies.Add(enemy);
        }

        public IEnumerator Spawn()
        {
            while(true) 
            {
                var newEnemy = Instantiate(currentEnemies[Random.Range(0, currentEnemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                yield return new WaitForSeconds(spawnRate);
            }
        }

        public void DeleteEnemies()
        {
            foreach (var enemy in currentEnemies)
            {
                Destroy(enemy);
            }
        }
    }
}
