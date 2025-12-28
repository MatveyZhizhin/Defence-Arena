using System.Collections;
using UnityEngine;


namespace Building
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private _Bullet _bullet;
        [SerializeField] private float _damage;
        [SerializeField] private float _fireRate;
        [SerializeField] private Transform _firePoint;

        private void Start()
        {
            StartCoroutine(Fire());
        }
        private IEnumerator Fire()
        {
            var newBullet = Instantiate(_bullet, _firePoint.position, transform.rotation);
            newBullet.SetDamage(_damage);
            yield return new WaitForSeconds(_fireRate);
        }
    }
}