using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PauseButton : MonoBehaviour
    {
        private Button pauseButton;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Joystick[] joysticks;
        private bool isPaused;

        private void Awake()
        {
            TryGetComponent(out pauseButton);
        }

        private void Start()
        {
            pauseButton?.onClick.AddListener(() => EnablePausePanel());
        }

        private void EnablePausePanel()
        {
            if (!isPaused)
            {
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(false);                        
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                foreach (var joystick in joysticks) joystick.gameObject.SetActive(true);
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
