using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Attacker attacker;
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform[] firePoints;
        [SerializeField] private AudioSource fireSound;

        [SerializeField] private float fireRate;

        [SerializeField] private UnityEvent onShot;

        private Aiming aiming;
        private bool isAttacking;

        private void Awake()
        {
            aiming = GetComponentInParent<Aiming>();
        }

        private void Update()
        {
            if (aiming.IsAimming)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(Fire());
                }
            }
            else
            {
                StopAllCoroutines();
                isAttacking = false;
            }
        }

        public IEnumerator Fire()
        {           
            while (true)
            {
                foreach (var firePoint in firePoints)
                {
                    fireSound.Play();
                    onShot?.Invoke();
                   var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                   newBullet.SetDamage(attacker.Damage);
                }
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}
