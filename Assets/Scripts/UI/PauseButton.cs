using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PauseButton : PanelActivationButton
    {
        [SerializeField] private Joystick[] joysticks;

        protected override void EnablePanel()
        {
            if (!isPressed)
            {
                panel.SetActive(true);
                Time.timeScale = 0f;
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);
                isPressed = true;
            }
        }

        protected override void DisablePanel()
        {
            if (isPressed)
            {
                panel.SetActive(false);
                Time.timeScale = 1f;
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(true);
                isPressed = false;
            }
        }
    }
}
