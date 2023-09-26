using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        private Button playButton;

        private void Awake()
        {
            TryGetComponent(out playButton);
        }

        private void Start()
        {
            playButton?.onClick.AddListener(() => Play());
        }

        private void Play()
        {           
            SceneManager.LoadScene(1);
        }
    }
}