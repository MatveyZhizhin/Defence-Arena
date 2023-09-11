using Assets.Scripts.UI.Upgrades;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UpgradesButtonsManager : MonoBehaviour
    {
        [SerializeField] private UpgradeButton[] firstButton;
        [SerializeField] private UpgradeButton[] secondButton;
        [SerializeField] private UpgradeButton[] thirdButton;
        [SerializeField] private UpgradeButton[] fourthButton;

        public event Action OnUpgrade;

        private List<UpgradeButton> currentButtons = new List<UpgradeButton>();

        private void Update()
        {
            DisableButtons();
        }

        public void EnableButtons()
        {
            currentButtons.Add(firstButton[Random.Range(0, firstButton.Length)]);
            currentButtons.Add(secondButton[Random.Range(0, secondButton.Length)]);
            currentButtons.Add(thirdButton[Random.Range(0, thirdButton.Length)]);
            currentButtons.Add(fourthButton[Random.Range(0, fourthButton.Length)]);

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
                    OnUpgrade?.Invoke();
                    foreach (var button in currentButtons)
                    {
                        button.gameObject.SetActive(false);                       
                    }
                    currentButtons.Clear();
                    break;
                }
            }
        }
    }
}