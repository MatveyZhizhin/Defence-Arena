using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DeathScreen : MonoBehaviour
    {
        private IPlayer player;
        [SerializeField] private Button returnButton;

        private void Awake()
        {
            player = FindObjectOfType<_Player>();           
        }

        private void OnEnable()
        {
            player.OnPlayerDeath += EnableDeathScreen;
            returnButton?.onClick.AddListener(() => ReturnToMainMenu());
        }

        private void EnableDeathScreen()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void ReturnToMainMenu()
        {
            player.OnPlayerDeath -= EnableDeathScreen;
            SceneManager.LoadScene(1);
        }
    }
}
