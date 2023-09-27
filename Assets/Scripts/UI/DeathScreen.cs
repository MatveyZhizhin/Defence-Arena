using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DeathScreen : MonoBehaviour
    {
        private IPlayer player;
        [SerializeField] private GameObject deathScreen;

        [SerializeField] private Joystick[] joysticks;

        private void Awake()
        {
            player = FindObjectOfType<_Player>();           
        }

        private void Start()
        {
            player.OnPlayerDeath += EnableDeathScreen;
        }

        private void EnableDeathScreen()
        {
            deathScreen.SetActive(true);
            foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        private void OnEnable()
        {
            player.OnPlayerDeath -= EnableDeathScreen;
        }       
    }
}
