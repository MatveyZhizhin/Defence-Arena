using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PauseButton : PanelActivationButton
    {
        [SerializeField] private Joystick[] joysticks;
        [SerializeField] private GunDisabler disabler;

        private bool isPaused;

        private void Update()
        {
            if (isPaused)
            {
                Time.timeScale = 0f;
                disabler.DisableGun();
            }
        }

        protected override void EnablePanel()
        {
            if (!isPressed)
            {
                panel.SetActive(true);
                isPaused = true;               
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);
                isPressed = true;
            }
        }

        protected override void DisablePanel()
        {
            if (isPressed)
            {
                panel.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
                disabler.EnableGun();
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(true);
                isPressed = false;
            }
        }
    }
}
