using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Upgrades
{
    [RequireComponent(typeof(Button))]
    public abstract class UpgradeButton : MonoBehaviour
    {
        [SerializeField] protected Image[] buttonIcons;
        protected Button upgradeButton;
        protected _Player player;

        private void Awake()
        {
            upgradeButton = GetComponent<Button>();
            player = FindObjectOfType<_Player>();
        }

        private void Start() => GenerateButton();

        protected abstract void GenerateButton();

        protected abstract void DoUpgrade();
    }
}
