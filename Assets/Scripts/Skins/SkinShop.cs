using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Skins
{
    public class SkinShop : MonoBehaviour
    {
        [SerializeField] private List<Skin> _skins;
        [SerializeField] private bool _isPreview;

        public event Action SkinBought;

        private void Start()
        {
            foreach (var skin in _skins)
            {
                if (skin.IsBought)
                    skin.Buy();

                if (_isPreview)
                {
                    skin.OnSkinSelection?.Invoke();
                    continue;
                }

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
                        break;
                    }
                }    
            }
        }

        public int GetSelectedSkinIndex()
        {
            foreach (var skin in _skins)
            {
                if (skin.IsSelected)
                {
                    return _skins.IndexOf(skin);
                }
            }

            return 0;
        }

        public void BuySkin(string index)
        {                                              
            _skins[int.Parse(index)].Buy();
            SkinBought?.Invoke();
        }

        public Skin[] GetSkins()
        {
            return _skins.ToArray();
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