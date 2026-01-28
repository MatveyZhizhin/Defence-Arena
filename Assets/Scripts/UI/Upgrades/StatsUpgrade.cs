using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Upgrades
{
    public enum Stats
    {
        Health,
        Damage,
        Speed
    }

    public class StatsUpgrade : UpgradeButton
    {
        private Stats stats;
            
        private int value;

        public Stats Stats => stats;
        public int Value => value;


        [SerializeField] private TextMeshProUGUI percentText;
        [SerializeField] private Chance statsChances;

        protected override void GenerateButton()
        {
            stats = (Stats)Randomizer.GetRandomIndexWithChance(statsChances.Chances);
            GenerateValue();
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

        public void GenerateValue()
        {
            value = Random.Range(2, 5);
            percentText.SetText("+" + value);
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
