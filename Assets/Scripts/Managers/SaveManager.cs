using Assets.Scripts.Player;
using UnityEngine;
using YG;

namespace Assets.Scripts.Managers
{
    public class SaveManager : MonoBehaviour
    {
        private Record record;

        private void Awake()
        {
            record = FindObjectOfType<Record>();
        }

        public void Save()
        {
            YandexGame.savesData.MaxRecord = record.MaxRecord;
            YandexGame.SaveProgress();
        }
    }
}
