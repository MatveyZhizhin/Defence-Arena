using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class ReturnButton : MonoBehaviour
    {
        private Button returnButton;
        [SerializeField] private int sceneIndex;

        private void Awake()
        {
            TryGetComponent(out returnButton);
        }

        private void Start()
        {
            returnButton?.onClick.AddListener(() => ReturnToMainMenu());
        }

        private void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
