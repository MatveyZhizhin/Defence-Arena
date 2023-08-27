using TMPro;
using UnityEngine;


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
            
        private int percent;


        [SerializeField] private TextMeshProUGUI percentText;        
        [SerializeField] private Bullet playerBullet;     

        protected override void GenerateButton()
        {
            stats = (Stats)Random.Range(0, 2);
            percent = Random.Range(1, 10);
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
            switch (stats)
            {
                case Stats.Health:  
                    player.Health += (percent * player.Health) / 100; 
                    break;

                case Stats.Damage:
                   playerBullet.Damage += (percent * playerBullet.Damage) / 100; 
                    break;
            }
        }
    }
}
