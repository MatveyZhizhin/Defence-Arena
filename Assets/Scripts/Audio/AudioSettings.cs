using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSources;

        private void Start()
        {
            SetVolume(1f);
        }

        public void SetVolume(float volume)
        {
            foreach (var source in _audioSources)
            {
                source.volume = volume;
            }
        }
    }
}

