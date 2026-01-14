using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

namespace Game.Skins
{
    public class SkinShop : MonoBehaviour
    {
        [SerializeField] private List<Skin> _skins;

        public UnityEvent OnMoneyLack;

        private void Start()
        {
            foreach (var skin in _skins)
            {
                if (skin.IsBought)
                    skin.Buy();

                if (skin.IsSelected)
                    skin.Select();
                else 
                    skin.Remove();
            }
        }

        public void ChangeSkin(int index)
        {
            foreach (var skin in _skins)
            {
                if (skin != _skins[index])
                {
                    if (skin.IsSelected && _skins[index].IsBought)
                    {
                        skin.Remove();
                        _skins[index].Select();
                    }
                }    
            }
        }

        public void BuySkin(string index)
        {                                              
            _skins[int.Parse(index)].Buy();
            ChangeSkin(int.Parse(index));
        }

        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += BuySkin;
        }

        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= BuySkin;
        }
    }
}