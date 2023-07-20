using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Shooter
{
    public class Shooter : Enemy
    {        
        [SerializeField] private EnemyBullet bullet;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate;
        //private bool isShooting;
        
        protected override void Attack()
        {
            
        }

        IEnumerator Fire()
        {
            //isShooting = true;
            while (true)
            {
                yield return new WaitForSeconds(fireRate);
                Instantiate(bullet, firePoint.position, transform.rotation);
            }           
        }
    }
}
