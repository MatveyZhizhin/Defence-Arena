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
        protected IPlayer player;

        public bool IsUpgraded { get; protected set; }

        private void Awake()
        {
            upgradeButton = GetComponent<Button>();
            player = FindObjectOfType<_Player>();
        }

        private void Start()
        {
            GenerateButton();
            upgradeButton?.onClick.AddListener(() => DoUpgrade());
        }

        private void OnDisable()
        {
            IsUpgraded = false;
        }

        protected abstract void GenerateButton();

        protected abstract void DoUpgrade();
    }
}
