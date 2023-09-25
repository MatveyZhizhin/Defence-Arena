using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Shooter : _Enemy
    {        
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform firePoint;     
        
        private void Fire()
        {
            var newBullet = Instantiate(bullet, firePoint.position, transform.rotation);
            newBullet.SetDamage(damage);
        }

        protected override IEnumerator Attack()
        {
            while (true)
            {
                enemyAnimator.SetTrigger("Attack");
                yield return new WaitForSeconds(attackRate);
            }
        }
    }
}
