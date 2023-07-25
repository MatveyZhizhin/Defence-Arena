using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Guns
{
    public class ShotGun : Gun
    {
        [SerializeField] private Transform firePoint1;
        [SerializeField] private Transform firePoint2;
        [SerializeField] private Transform firePoint3;

        protected override IEnumerator Fire()
        {
            while (true)
            {
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                Instantiate(bullet, firePoint2.position, firePoint2.rotation);
                Instantiate(bullet, firePoint3.position, firePoint3.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}