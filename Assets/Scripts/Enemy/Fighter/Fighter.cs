using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Fighter
{   
    public class Fighter : Enemy
    {
        [SerializeField] private float damage;

        private void Hit()
        {
            _player.TakeDamage(damage);
        }

        protected override IEnumerator Attack()
        {
            while (true)
            {
                Hit();
                yield return new WaitForSeconds(attackRate);
            }            
        }       
    }
}