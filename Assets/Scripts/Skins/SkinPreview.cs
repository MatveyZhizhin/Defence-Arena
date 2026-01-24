using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

namespace Skins
{
    [RequireComponent(typeof(SkinShop))]
    public class SkinPreview : MonoBehaviour
    {
        private SkinShop _skinShop;
        private Skin[] _skins;
        [SerializeField] private PurchaseYG _purchaseButton;
        [SerializeField] private Button _selectionButton;

        [SerializeField] private int _currentIndex;
        [SerializeField] private TextMeshProUGUI _nameText;

        [SerializeField] private UnityEvent _onSwitch;

        private SaveManager _saveManager;

        private void Awake()
        {
            TryGetComponent(out _skinShop);
            _saveManager = FindObjectOfType<SaveManager>();
        }

        private void Start()
        {
            _skins = _skinShop.GetSkins();
            _purchaseButton.data = YandexGame.PurchaseByID(_currentIndex.ToString());
            ChangeSelected();
        }

        public void SwitchNext()
        {
            _skins[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex > _skins.Length - 1)
            {
                _currentIndex = 0;
            }
            var skin = _skins[_currentIndex];
            skin.gameObject.SetActive(true);
            _purchaseButton.data = YandexGame.PurchaseByID(_currentIndex.ToString());
            _onSwitch?.Invoke();
            SwitchButton(skin);
        }

        private void SwitchButton(Skin skin)
        {
            if (skin.IsBought)
            {
                skin.OnSkinPurchase?.Invoke();

                if (skin.IsSelected)
                    skin.OnSkinSelection.Invoke();
            }
            else
            {
                _purchaseButton.gameObject.SetActive(true);
                _selectionButton.gameObject.SetActive(false);
            }

            _nameText.SetText(skin.Name);
        }

        public void SwitchPrevious()
        {
            _skins[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _skins.Length - 1;
            }
            var skin = _skins[_currentIndex];
            skin.gameObject.SetActive(true);
            _purchaseButton.data = YandexGame.PurchaseByID(_currentIndex.ToString());
            _onSwitch.Invoke();
            SwitchButton(skin);
        }        

        public void ChangeSkin()
        {
            _skinShop.ChangeSkin(_currentIndex);
            SwitchButton(_skins[_currentIndex]);
            _saveManager.SaveSkins();
        } 

        public void ChangeSelected()
        {
            while(_currentIndex != _skinShop.GetSelectedSkinIndex())
            {
                SwitchNext();
            }
            _nameText.SetText(_skins[_currentIndex].Name);
        }

        private void OnEnable()
        {
            _skinShop.SkinBought += ChangeSkin;
        }

        private void OnDisable()
        {
            _skinShop.SkinBought -= ChangeSkin;
        }
    }
}
