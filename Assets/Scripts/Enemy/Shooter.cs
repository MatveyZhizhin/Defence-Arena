using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Shooter : _Enemy
    {        
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform firePoint;            

        protected override IEnumerator Attack()
        {
            while (true)
            {                
                var newBullet = Instantiate(bullet, firePoint.position, transform.rotation);
                newBullet.SetDamage(damage);
                yield return new WaitForSeconds(attackRate);
            }
        }
    }
}
