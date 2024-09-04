using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSources;

        public void SetVolume(float volume)
        {
            foreach (var source in _audioSources)
            {
                source.volume = volume;
            }
        }
    }
}

