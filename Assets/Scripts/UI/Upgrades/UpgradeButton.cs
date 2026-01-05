using Assets.Scripts.Managers;
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
        protected SpawnManager spawnManager;

        public bool IsUpgraded { get; protected set; }

        private void Awake()
        {
            upgradeButton = GetComponent<Button>();
            player = FindObjectOfType<_Player>();
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        private void Start()
        {
            upgradeButton?.onClick.AddListener(() => DoUpgrade());
        }

        private void OnEnable()
        {
            GenerateButton();
        }

        private void OnDisable()
        {
            IsUpgraded = false;
        }

        protected abstract void GenerateButton();

        protected abstract void DoUpgrade();
    }
}
