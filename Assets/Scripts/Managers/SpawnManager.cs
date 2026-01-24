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

        public event Action EnemiesDied;

        public void AddEnemy(ref List<_Enemy> enemies)
        {
            currentEnemies.Add(enemies[0]);
            enemies.Remove(enemies[0]);
        }

        public IEnumerator Spawn(int amount, int healthMultiplier = 1, float speedMultiplier = 1)
        {
            remainingEnemiesText.SetText(amount.ToString());
            remainingEnemiesAmount = amount;

            for (int i = 0; i < amount; i++)
            {
                var enemyIndex = Randomizer.GetRandomIndexWithChance(enemiesChances.Chances.GetRange(0, currentEnemies.Count));
                var newEnemy = Instantiate(currentEnemies[enemyIndex], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
                newEnemy.IncreaseHealth(healthMultiplier);
                newEnemy.IncreaseSpeed(speedMultiplier);
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
