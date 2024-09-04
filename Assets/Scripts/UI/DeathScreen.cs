using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class DeathScreen : MonoBehaviour
    {
        private IPlayer player;
        [SerializeField] private GameObject deathScreen;

        [SerializeField] private Joystick[] joysticks;
        private GunDisabler disabler;

        private void Awake()
        {
            player = FindObjectOfType<_Player>();   
            disabler = FindObjectOfType<GunDisabler>();
        }

        private void Start()
        {
            player.OnPlayerDeath += EnableDeathScreen;
            player.OnPlayerRevive += DisableDeathScreen;
            Time.timeScale = 1f;
        }

        private void EnableDeathScreen()
        {
            deathScreen.SetActive(true);
            foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);
            disabler.DisableGun();
            Time.timeScale = 0f;
        }

        private void DisableDeathScreen()
        {
            deathScreen.SetActive(false);
            foreach (var joystick in joysticks) joystick.gameObject.SetActive(true);
            disabler.EnableGun();
            Time.timeScale = 1f;
        }

        private void OnEnable()
        {
            player.OnPlayerDeath -= EnableDeathScreen;
            player.OnPlayerRevive -= DisableDeathScreen;
        }       
    }
}
