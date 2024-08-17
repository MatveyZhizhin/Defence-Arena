using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.Player
{
    public class Record : MonoBehaviour
    {
        public int MaxRecord { get; set; } 
        [SerializeField] private TextMeshProUGUI recordText;

        private SaveManager saveManager;

        private const string YandexLeaderboardName = "Record";

        private void Awake()
        {
            saveManager = FindObjectOfType<SaveManager>();
        }

        private void Start()
        {
            MaxRecord = YandexGame.savesData.MaxRecord;
            recordText.SetText($"Рекорд: {MaxRecord}");
        }

        public void ChangeRecord(int newRecord)
        {
            if (MaxRecord < newRecord)
            {
                MaxRecord++;
                recordText.SetText($"Рекорд: {MaxRecord}");
                YandexGame.NewLeaderboardScores(YandexLeaderboardName, MaxRecord);
                saveManager.Save();
            }
        }

        public void ResetRecord()
        {
            YandexGame.ResetSaveProgress();
            YandexGame.NewLeaderboardScores(YandexLeaderboardName, 0);
            SceneManager.LoadScene(0);
            YandexGame.SaveProgress();
        }
    }
}
