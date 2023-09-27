using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PanelActivationButton : MonoBehaviour
    {
        private Button button;
        [SerializeField] private Button exitButton;

        [SerializeField] protected GameObject panel;

        protected bool isPressed;

        private void Awake()
        {
            TryGetComponent(out button);
        }

        private void Start()
        {
            button?.onClick.AddListener(() => EnablePanel());
            exitButton?.onClick.AddListener(() => DisablePanel());
        }

        protected virtual void EnablePanel()
        {
            if (!isPressed)
            {
                panel.SetActive(true);
                isPressed = true;
            }           
        }

        protected virtual void DisablePanel()
        {
            if (isPressed)
            {
                panel.SetActive(false);
                isPressed = false;
            }
        }
    }
}
