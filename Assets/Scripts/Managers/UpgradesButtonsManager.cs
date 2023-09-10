using Assets.Scripts.UI.Upgrades;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UpgradesButtonsManager : MonoBehaviour
    {
        [SerializeField] private UpgradeButton[] firstButton;
        [SerializeField] private UpgradeButton[] secondButton;
        [SerializeField] private UpgradeButton[] thirdButton;
        [SerializeField] private UpgradeButton[] fourthButton;

        private List<UpgradeButton> currentButtons;

        private void Start()
        {
            EnableButtons();
        }

        private void Update()
        {
            DisableButtons();
        }

        public void EnableButtons()
        {
            currentButtons = new List<UpgradeButton>
            {
                firstButton[Random.Range(0, firstButton.Length)],
                secondButton[Random.Range(0, secondButton.Length)],
                thirdButton[Random.Range(0, thirdButton.Length)],
                fourthButton[Random.Range(0, fourthButton.Length)]
            };

            foreach (var button in currentButtons)
            {
                button.gameObject.SetActive(true);
            }
        }

        private void DisableButtons()
        {
            foreach (var upgrade in currentButtons)
            {
                if (upgrade.IsUpgraded)
                {
                    foreach (var button in currentButtons)
                    {
                        button.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}