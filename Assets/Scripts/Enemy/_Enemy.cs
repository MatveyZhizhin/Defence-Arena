using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class _Enemy : MonoBehaviour, IEnemy
    {
        protected _Player _player;
        private SpawnManager spawnManager;
        protected Animator enemyAnimator;

        [SerializeField] private float speed;
        [SerializeField] private float health;
        [SerializeField] protected float damage;

        [SerializeField] protected float minDistance;
        [SerializeField] protected float attackDistance;
        [SerializeField] protected float attackRate;


        protected float currentDistance;

        private bool isAttacking;        

        private void Awake()
        {
            _player = FindObjectOfType<_Player>();
            spawnManager = FindObjectOfType<SpawnManager>();
            TryGetComponent(out enemyAnimator);
        }

        private void Update()
        {
            Move();
        }

        protected abstract IEnumerator Attack();

        public void TakeDamage(float damage)
        {          
            health -= damage;

            if (health <= 0)
            {
                spawnManager.RemoveEnemy(this);
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            currentDistance = Vector3.Distance(_player.transform.position, transform.position);
            transform.LookAt(_player.transform.position);
            if (currentDistance > minDistance)
            {               
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
            }

            if (currentDistance < attackDistance)
            {                

                if (!isAttacking)
                {
                    StartCoroutine(Attack());
                    isAttacking = true;
                }                                          
            }
            else
            {
                StopAllCoroutines();
                isAttacking = false;
            }                   
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;            
            Gizmos.DrawWireSphere(transform.position, minDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }       
    }
}
