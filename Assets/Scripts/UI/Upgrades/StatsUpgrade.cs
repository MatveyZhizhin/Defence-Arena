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
        [SerializeField] private float maxValue;


        [SerializeField] private TextMeshProUGUI percentText;        
        [SerializeField] private Bullet playerBullet;     

        protected override void GenerateButton()
        {
            stats = (Stats)Random.Range(0, 2);
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
            upgradeButton?.onClick.AddListener(() => DoUpgrade());
        }

        protected override void DoUpgrade()
        {
            switch (stats)
            {
                case Stats.Health:  
                    player.Health += (percent * maxValue) / 100; 
                    break;

                case Stats.Damage:
                   playerBullet.Damage += (percent * maxValue) / 100; 
                    break;
            }
        }
    }
}
