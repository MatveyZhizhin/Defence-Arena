using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private List<_Enemy> currentEnemies;

        private List<_Enemy> spawnedEnemies = new List<_Enemy>();

        [SerializeField] private float spawnRate;

        public float SpawnRate { get => spawnRate; set => spawnRate = value; }

        public void AddEnemy(_Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                foreach (var currentEnemy in currentEnemies)
                {
                    if (enemy != currentEnemy)
                    {
                        currentEnemies.Add(enemy);
                        return;
                    }
                }
            }
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

        public void RemoveEnemy(_Enemy enemy)
        {
            spawnedEnemies.Remove(enemy);
        }

        public void DeleteEnemies()
        {                      
            foreach (var enemy in spawnedEnemies.ToList())
            {
                if (spawnedEnemies != null)
                {
                    spawnedEnemies.Remove(enemy);
                    Destroy(enemy.gameObject);
                }
                else
                {
                    return;
                }           
            }
        }
    }
}
