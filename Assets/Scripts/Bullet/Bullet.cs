using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class _Bullet : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private float distance;
        [SerializeField] private LayerMask solid;

        private void Update()
        {
            Fire();
        }

        private void Fire()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance, solid))
            {                
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.TryGetComponent(out IAttackable obj))
                    {
                        obj.TakeDamage(damage);
                    }
                    Destroy(gameObject);
                }               
            }
            Destroy(gameObject, lifeTime);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * distance);
        }
    }
}
