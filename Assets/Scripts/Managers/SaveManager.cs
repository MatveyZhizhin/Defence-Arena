using Assets.Scripts.Player;
using Skins;
using UnityEngine;
using YG;

namespace Assets.Scripts.Managers
{
    public class SaveManager : MonoBehaviour
    {
        private Record record;
        private SkinShop skinShop;

        private void Awake()
        {
            record = FindObjectOfType<Record>();
            skinShop = FindObjectOfType<SkinShop>();
            Load();
        }

        public void Save()
        {
            YandexGame.savesData.MaxRecord = record.MaxRecord;           

            YandexGame.SaveProgress();
        }

        public void SaveSkins()
        {
            var skins = skinShop.GetSkins();

            for (int i = 0; i < YandexGame.savesData.IsBought.Length; i++)
            {
                YandexGame.savesData.IsBought[i] = skins[i].IsBought;
                YandexGame.savesData.IsSelected[i] = skins[i].IsSelected;
            }

            YandexGame.SaveProgress();
        }

        private void Load()
        {
            var skins = skinShop.GetSkins();

            for (int i = 0; i < YandexGame.savesData.IsBought.Length; i++)
            {
                skins[i].IsBought = YandexGame.savesData.IsBought[i];
                skins[i].IsSelected = YandexGame.savesData.IsSelected[i];               
            }
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += Load;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Load;
        }
    }
}
