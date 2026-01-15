using System.Collections;
using Assets.Scripts.Enemy;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBeforeTheExplosion;
    [SerializeField] private AudioSource _audioSources;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField]private GameObject _granate;

    private void OnEnable()
    {
        _particleSystem.Stop();
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(_timeBeforeTheExplosion);
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);
        _audioSources.Play();
        _particleSystem.Play();
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out _Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
        Destroy(_granate);
        Destroy(gameObject, 5);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
