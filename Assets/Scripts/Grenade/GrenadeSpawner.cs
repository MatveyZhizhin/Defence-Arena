using UnityEngine;

namespace Grenade
{
    public class GrenadeSpawner : MonoBehaviour
    {
        [SerializeField] private Explosion _grenadePrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _force;

        private GrenadeCounter _grenadeCounter;

        private void Awake()
        {
            _grenadeCounter = FindObjectOfType<GrenadeCounter>();
        }

        public void SpawnGrenade()
        {
            if (!_grenadeCounter.HasGrenades)
                return;

            var newGrenade = Instantiate(_grenadePrefab, _spawnPoint.position, _spawnPoint.rotation);
            newGrenade.GetComponent<Rigidbody>().AddForce(newGrenade.transform.forward *  _force, ForceMode.Impulse);
            _grenadeCounter.Decrease();
        }
    }
}
