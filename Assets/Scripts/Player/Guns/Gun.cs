using Assets.Scripts.Bullet;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Joystick joystick;

        private bool isAttacking;

        [SerializeField] protected float fireRate;

        private void Update()
        {
            Move();
        }

        protected virtual IEnumerator Fire()
        {           
            while (true)
            {
                Instantiate(bullet, firePoint.position, transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }

        private void Move()
        {
            var rot = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(5f, rot, 0f);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (!isAttacking)
                {
                    StartCoroutine(Fire());
                    isAttacking = true;
                }                              
            }
            else
            {
                StopAllCoroutines();
                isAttacking = false;
            }
        }
    }
}
