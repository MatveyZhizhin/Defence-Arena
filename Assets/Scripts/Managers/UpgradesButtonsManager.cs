using Assets.Scripts.UI.Upgrades;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UpgradesButtonsManager : MonoBehaviour
    {
        [SerializeField] private List<UpgradeButton> _buttons;

        public event Action OnUpgrade;

        private void Update()
        {
            DisableButtons();
        }

        public void EnableButtons()
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActive(true);
            }
            CheckValues();
        }

        private void DisableButtons()
        {
            foreach (var upgrade in _buttons)
            {
                if (upgrade.IsUpgraded)
                {
                    OnUpgrade?.Invoke();
                    foreach (var button in _buttons)
                    {
                        button.gameObject.SetActive(false);                       
                    }
                    break;
                }
            }
        }

        private void CheckValues()
        {
           List<StatsUpgrade> buttons = new();

            foreach (var upgrade in _buttons)
            {
                if(upgrade.TryGetComponent(out StatsUpgrade statsUpgrade))
                {
                    buttons.Add(statsUpgrade);
                }
            }

            for (int i = 0; i < buttons.Count; i++)
            {
                for (int j = i; j < buttons.Count; j++)
                {
                    if (buttons[i] == buttons[j])
                        continue;

                    while (buttons[i].Stats == buttons[j].Stats && buttons[i].Value == buttons[j].Value)
                    {
                        buttons[i].GenerateValue();
                    } 
                }
            }
        }
    }
}