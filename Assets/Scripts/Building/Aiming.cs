using Assets.Scripts.Enemy;
using UnityEngine;

namespace Building
{

    public class Aiming : MonoBehaviour
    {
        [SerializeField] private Transform _gun;
        [SerializeField] private float _attackDistance;


        void Update()
        {
            _gun.LookAt(GetNearestEnemyPhysics());
        }


        private Transform GetNearestEnemyPhysics()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _attackDistance);
            

            Transform nearest = null;
            float minDist = _attackDistance;

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out _Enemy enemy)) { 
                    float distance = Vector3.Distance(transform.position, hit.transform.position);
                    if (distance < minDist)
                    {
                        minDist = distance;
                        nearest = hit.transform;
                    }
                }
            }

            return nearest;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _attackDistance);
        }

    }
}
