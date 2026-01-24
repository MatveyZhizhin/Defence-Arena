using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Timer))]
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Image _timerImage;
        private Timer _timer;

        private void Awake()
        {
            TryGetComponent(out _timer);
        }

        private void RenderTimer(float time)
        {
            _timerImage.fillAmount = time;
        }


        private void OnEnable()
        {
            _timer.Updated += RenderTimer;
        }

        private void OnDisable()
        {
            _timer.Updated -= RenderTimer;
        }
    }
}
