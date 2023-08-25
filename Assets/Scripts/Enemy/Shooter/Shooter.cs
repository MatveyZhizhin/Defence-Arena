using Assets.Scripts.Bullet;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Shooter
{
    public class Shooter : _Enemy
    {        
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform firePoint;

        protected override IEnumerator Attack()
        {
            while (true)
            {                
                Instantiate(bullet, firePoint.position, transform.rotation);
                yield return new WaitForSeconds(attackRate);
            }
        }
    }
}
