using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{   
    public class Fighter : _Enemy
    {
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