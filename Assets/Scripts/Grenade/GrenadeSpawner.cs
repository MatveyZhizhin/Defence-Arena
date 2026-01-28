using TMPro;
using UnityEngine;
using YG;

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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnGrenade();
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
