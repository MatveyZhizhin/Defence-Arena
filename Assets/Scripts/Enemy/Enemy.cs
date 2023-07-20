
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private _Player _player;

        [SerializeField] private float speed;
        [SerializeField] protected float damage;
        [SerializeField] protected float minDistance;
        [SerializeField] protected float maxDistance;
        protected float currentDistance;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = FindObjectOfType<_Player>();
        }

        private void Update()
        {
            Move();
        }

        protected abstract void Attack();

        private void Move()
        {
            currentDistance = Vector3.Distance(_player.transform.position, transform.position);
            if (currentDistance > minDistance)
            {
                transform.LookAt(_player.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
            }            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxDistance);
            Gizmos.DrawWireSphere(transform.position, minDistance);
        }
    }
}
