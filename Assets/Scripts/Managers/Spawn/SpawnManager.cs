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
        [SerializeField] private float spawnRate;      

        public void AddEnemy(_Enemy enemy)
        {
            currentEnemies.Add(enemy);
        }

        public IEnumerator Spawn(int enemyCount)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(currentEnemies[Random.Range(0, currentEnemies.Count - 1)], spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
