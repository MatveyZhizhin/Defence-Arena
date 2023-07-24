using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Guns
{
    public class Shot_gun : Gun
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform firePoint2;
        [SerializeField] private Transform firePoint3;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override IEnumerator Fire()
        {
            isAttacking = true;
            while (true)
            {
                Instantiate(bullet, firePoint.position, transform.rotation);
                Instantiate(bullet, firePoint2.position, transform.rotation);
                Instantiate(bullet, firePoint3.position, transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}