using Assets.Scripts.Enemy;
using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private Chance enemiesChances;

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
                var enemyIndex = Randomizer.GetRandomIndexWithChance(enemiesChances.Chances.GetRange(0, currentEnemies.Count));
                print(enemyIndex);
                var newEnemy = Instantiate(currentEnemies[enemyIndex], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                newEnemy.AddHealth(AdditionalHealth);
                newEnemy.AddSpeed(AdditionalSpeed);
                yield return new WaitForSeconds(spawnRate);
            }           
        }

        public void RemoveEnemy(_Enemy enemy)
        {
            if (!spawnedEnemies.Contains(enemy))
                return;
            spawnedEnemies.Remove(enemy);
            remainingEnemiesAmount--;
            remainingEnemiesText.SetText(remainingEnemiesAmount.ToString());
            if(spawnedEnemies.Count == 0)
                EnemiesDied?.Invoke();
        }
    }
}
