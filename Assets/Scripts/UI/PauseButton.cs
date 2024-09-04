using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PauseButton : PanelActivationButton
    {
        [SerializeField] private Joystick[] joysticks;
        [SerializeField] private GunDisabler disabler;


        protected override void EnablePanel()
        {
            if (!isPressed)
            {
                panel.SetActive(true);
                disabler.DisableGun();
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);
                Time.timeScale = 0f;
                isPressed = true;
            }
        }

        protected override void DisablePanel()
        {
            if (isPressed)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
                disabler.EnableGun();
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(true);
                isPressed = false;
            }
        }
    }
}
