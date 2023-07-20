
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float damage;
        [SerializeField] protected float minDistance;
        [SerializeField] protected float maxDistance;
        protected float currentDistance;

        private void Update()
        {
            Attack();
        }

        protected abstract void Attack();

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxDistance);
            Gizmos.DrawWireSphere(transform.position, minDistance);
        }
    }
}
