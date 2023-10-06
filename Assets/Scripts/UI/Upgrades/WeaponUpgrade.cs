using UnityEngine;
using Assets.Scripts.Player;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Upgrades
{
    public class WeaponUpgrade : UpgradeButton
    {
        [SerializeField] private Gun[] weapons;

        private Gun newWeapon;

        protected override void GenerateButton()
        {
            newWeapon = weapons[Random.Range(0, weapons.Length)];

            foreach (var weapon in weapons)
            {
                if (weapon.gameObject.activeInHierarchy)
                {
                    while (newWeapon == weapon)
                    {
                        newWeapon = weapons[Random.Range(0, weapons.Length)];
                    }
                }
            }

            foreach (var icon in buttonIcons)
            {
                if (icon.name == newWeapon.name)
                {
                    upgradeButton.GetComponent<Image>().sprite = icon.sprite;
                    upgradeButton.GetComponent<Image>().SetNativeSize();
                    break;
                }
            }            
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
            IsUpgraded = true;
        }       
    }
}