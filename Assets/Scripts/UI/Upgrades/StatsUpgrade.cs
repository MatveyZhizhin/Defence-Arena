using Assets.Scripts.Player;
using TMPro;
using UnityEngine;


namespace Assets.Scripts.UI.Upgrades
{
    enum Stats
    {
        Health,
        Damage,
    }

    public class StatsUpgrade : UpgradeButton
    {
        private Stats stats;
        private int percent;
        [SerializeField] private TextMeshProUGUI percentText;        

        protected override void GenerateButton()
        {
            stats = (Stats)Random.Range(0, 1);
            percent = Random.Range(1, 100);
            percentText.SetText(percent.ToString());
            foreach (var icon in buttonIcons)
            {
                if (icon.name == stats.ToString())
                {
                    upgradeButton.GetComponent<SpriteRenderer>().sprite = icon.sprite;
                    break;
                }
            }
        }

        protected override void DoUpgrade()
        {
          
        }
    }
}
