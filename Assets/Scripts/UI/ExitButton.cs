using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private Button exitButton;
        [SerializeField] private GameObject panel;

        private void Awake()
        {
            TryGetComponent(out exitButton);
        }

        private void Start()
        {
            exitButton?.onClick.AddListener(() => ExitPanel());
        }

        private void ExitPanel()
        {
            panel.SetActive(false);
        }
    }
}
