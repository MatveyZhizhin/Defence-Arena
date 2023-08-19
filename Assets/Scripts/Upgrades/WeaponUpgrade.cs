using UnityEngine;
using Assets.Scripts.Player.Guns;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Upgrades
{
    public class WeaponUpgrade : UpgradeButton
    {
        [SerializeField] private Gun[] weapons;
        [SerializeField] private Image[] buttonIcons;

        private Gun newWeapon;

        protected override void GenerateButton()
        {
            newWeapon = weapons[Random.Range(0, weapons.Length)];

            foreach (var icon in buttonIcons)
            {
                if (icon.name == newWeapon.name)
                {
                    upgradeButton.GetComponent<SpriteRenderer>().sprite = icon.sprite;
                    icon.SetNativeSize();
                    break;
                }
            }

            upgradeButton?.onClick.AddListener(() => DoUpgrade());
        }

        protected override void DoUpgrade()
        {
            foreach (var weapon in weapons)
            {
                if (weapon.gameObject.activeInHierarchy)
                {
                    weapon.gameObject.SetActive(false);
                    newWeapon.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}