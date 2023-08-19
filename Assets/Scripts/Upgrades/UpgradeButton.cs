using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Upgrades
{    
    public abstract class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private Image[] buttonIcons;

        protected Button upgradeButton;

        private void Awake()
        {
            upgradeButton = GetComponent<Button>();
        }

        private void Start() => GenerateButton();   

        protected abstract void GenerateButton();

        protected abstract void DoUpgrade();
    }
}
