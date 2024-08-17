using RimuruDev;
using System.Collections;
using UnityEngine;
using YG;

namespace Assets.Scripts.Player
{
    public class Gun : MonoBehaviour
    {
        private IPlayer player;
        [SerializeField] private float offset;
        [SerializeField] private _Bullet bullet;
        [SerializeField] private Transform[] firePoints;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Animator cameraAnimator;
        private DeviceTypeDetector detector;

        private bool isAttacking;

        [SerializeField] protected float fireRate;

        private void Awake()
        {
            player = FindObjectOfType<_Player>();
            detector = FindObjectOfType<DeviceTypeDetector>();
        }

        private void Update()
        {
            MoveGun();
        }

        private IEnumerator Fire()
        {           
            while (true)
            {
                foreach (var firePoint in firePoints)
                {
                    cameraAnimator.SetTrigger("Shake");
                   var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                   newBullet.SetDamage(player.Damage);
                }
                yield return new WaitForSeconds(fireRate);
            }
        }

        private void MoveGun()
        {
            float rot;

            if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile)
            {
                rot = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;


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
                    transform.rotation = transform.parent.rotation;
                }
            }
            else
            {
                joystick.gameObject.SetActive(false);

                var difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

                rot = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

                if (Input.GetMouseButton(0))
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
                    transform.rotation = transform.parent.rotation;
                }
            }

            transform.rotation = Quaternion.Euler(0f, rot + offset, 0f);
        }
    }
}
