using Grenade;
using TMPro;
using UnityEngine;
using YG;

namespace Assets.Scripts.UI.Upgrades
{
    public class GrenadeUpgradeButton : UpgradeButton
    {
        [SerializeField] private GrenadeCounter _grenadeCounter;
        [SerializeField] private int _amount;
        [SerializeField] private TextMeshProUGUI _amountText;

        private const int _id = 3;

        protected override void DoUpgrade()
        {
            YandexGame.RewVideoShow(_id);
        }

        private void AddGrenades(int id)
        {
            if (id != _id)
                return;

            _grenadeCounter.Increase(_amount);
            IsUpgraded = true;
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += AddGrenades;
            _amountText.SetText($"+ {_amount} гранат");
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= AddGrenades;
            IsUpgraded = false;
        }

        protected override void GenerateButton()
        {
            return;
        }
    }
}
