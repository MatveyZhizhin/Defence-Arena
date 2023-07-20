using Assets.Scripts.Bullet;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Shooter
{
    public class Shooter : Enemy
    {        
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate;

        protected override IEnumerator Attack()
        {
            while (true)
            {                
                Instantiate(bullet, firePoint.position, transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}
