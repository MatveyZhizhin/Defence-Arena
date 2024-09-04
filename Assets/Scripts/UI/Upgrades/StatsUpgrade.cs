using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Upgrades
{
    enum Stats
    {
        Health,
        Damage,
        Speed
    }

    public class StatsUpgrade : UpgradeButton
    {
        private Stats stats;
            
        private int value;


        [SerializeField] private TextMeshProUGUI percentText;             

        protected override void GenerateButton()
        {
            stats = (Stats)Random.Range(0, 3);
            value = Random.Range(2, 6);
            percentText.SetText(value.ToString());
            foreach (var icon in buttonIcons)
            {                
                if (icon.name == stats.ToString())
                {
                    upgradeButton.GetComponent<Image>().sprite = icon.sprite;
                    upgradeButton.GetComponent<Image>().SetNativeSize();
                    break;
                }
            }            
        }

        protected override void DoUpgrade()
        {
            switch (stats)
            {
                case Stats.Health:
                    player.CurrentHealth += value;
                    player.UpdateHealth();
                    break;

                case Stats.Damage:
                    player.Damage += value;
                    break;

                case Stats.Speed:
                    player.Speed += value;
                    break;
            }
            IsUpgraded = true;
        }
    }
}
