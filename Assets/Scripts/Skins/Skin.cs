using UnityEngine;
using UnityEngine.Events;

namespace Game.Skins
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private bool _isBought;
        [SerializeField] private bool _isSelected;

        public UnityEvent OnSkinPurchase;
        public UnityEvent OnSkinSelection;

        public bool IsBought { get => _isBought; set => _isBought = value; }
        public bool IsSelected { get => _isSelected; set => _isSelected = value; }

        public void Select()
        {
            _isSelected = true;
            gameObject.SetActive(true);
            OnSkinSelection.Invoke();
        }

        public void Remove()
        {
            _isSelected = false;
            gameObject.SetActive(false);
            if(_isBought)
                OnSkinPurchase?.Invoke();
        }

        public void Buy()
        {
            _isBought = true;
            OnSkinPurchase?.Invoke();
        }
    }
}
