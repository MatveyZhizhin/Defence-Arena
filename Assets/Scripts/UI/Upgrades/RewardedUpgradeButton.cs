using Assets.Scripts.Player;
using UnityEngine;
using YG;

namespace  Assets.Scripts.UI.Upgrades
{
    public class RewardedUpgradeButton : UpgradeButton
    {
        [SerializeField] private Gun[] guns;
        [SerializeField] private Gun rewardedGun;

        [SerializeField] private Timer rewardTimer;

        private const int rewardedGunId = 2;

        private Gun currentGun;

        protected override void DoUpgrade()
        {
            YandexGame.RewVideoShow(rewardedGunId);
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += EnableRewardedGun;
            rewardTimer.Ended -= DisableRewardedGun;          
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= EnableRewardedGun;
            rewardTimer.Ended += DisableRewardedGun;
            IsUpgraded = false;
        }

        private void EnableRewardedGun(int id)
        {
            if (rewardedGunId == id)
            {
                foreach (var gun in guns)
                {
                    if (gun.gameObject.activeInHierarchy)
                    {
                        currentGun = gun;
                        gun.gameObject.SetActive(false);
                        rewardedGun.gameObject.SetActive(true);
                        break;
                    }
                }
                IsUpgraded = true;
                rewardTimer.StartTimer();
            }          
        }

        private void DisableRewardedGun()
        {
            rewardedGun.gameObject.SetActive(false);
            currentGun.gameObject.SetActive(true);
        }

        protected override void GenerateButton()
        {
            return;
        }
    }
}
