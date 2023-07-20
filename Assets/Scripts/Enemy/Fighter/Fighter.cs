
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Fighter
{   
    public class Fighter : Enemy
    {
        [SerializeField] private float damage;
        protected override IEnumerator Attack()
        {
            while (true)
            {
                _player.TakeDamage(damage);
                yield return new WaitForSeconds(1);
            }
        }
    }
}