using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Guns
{
    public class Shotgun : Gun
    {
        protected override IEnumerator Fire()
        {
            while (true)
            {
                foreach (var firePoint in firePoints)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}