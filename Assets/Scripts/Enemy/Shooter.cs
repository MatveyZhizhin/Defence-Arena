using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Shooter : _Enemy
    {        
        [SerializeField] private Bullet bullet;
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
