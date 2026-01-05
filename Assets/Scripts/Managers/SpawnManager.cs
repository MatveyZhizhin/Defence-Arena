using Assets.Scripts.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private List<_Enemy> currentEnemies;
        [SerializeField] private TextMeshProUGUI remainingEnemiesText;

        private List<_Enemy> spawnedEnemies = new List<_Enemy>();
        private int remainingEnemiesAmount;

        [SerializeField] private float spawnRate;

        public float SpawnRate { get => spawnRate; set => spawnRate = value; }

        public int AdditionalHealth { get; set; }
        public float AdditionalSpeed { get; set; }

        public event Action EnemiesDied;

        public void AddEnemy(_Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy != currentEnemies[currentEnemies.Count - 1])
                {
                    currentEnemies.Add(enemy);
                    return;
                }
            }
        }

        public IEnumerator Spawn(int amount)
        {
            remainingEnemiesText.SetText(amount.ToString());
            remainingEnemiesAmount = amount;
            for (int i = 0; i < amount; i++)
            {
                var newEnemy = Instantiate(currentEnemies[Random.Range(0, currentEnemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                newEnemy.AddHealth(AdditionalHealth);
                newEnemy.AddSpeed(AdditionalSpeed);
                yield return new WaitForSeconds(spawnRate);
            }           
        }

        public void RemoveEnemy(_Enemy enemy)
        {
            spawnedEnemies.Remove(enemy);
            remainingEnemiesAmount--;
            remainingEnemiesText.SetText(remainingEnemiesAmount.ToString());
            if(spawnedEnemies.Count == 0)
                EnemiesDied?.Invoke();
        }
    }
}
