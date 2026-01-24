using TMPro;
using UnityEngine;

namespace Grenade
{
    public class GrenadeCounter : MonoBehaviour
    {
        [SerializeField] private int _counter;
        [SerializeField] private Timer _timer;
        [SerializeField] private TextMeshProUGUI _counterText;

        public bool HasGrenades => _counter > 0;

        private void Start()
        {
            _timer.StartTimer();
            _counterText.SetText(_counter.ToString());
        }

        public void Increase(int value)
        {
            _counter += value;
            _counterText.SetText(_counter.ToString());
        }

        public void Increase()
        {
            _counter++;
            _counterText.SetText(_counter.ToString());
        }

        public void Decrease(int value = 1)
        {
            _counter -= value;
            _counterText.SetText(_counter.ToString());
        }

        private void OnEnable()
        {
            _timer.Ended += Increase;
            _timer.Ended += _timer.StartTimer;
        }

        private void OnDisable()
        {
            _timer.Ended -= Increase;
            _timer.Ended -= _timer.StartTimer;
        }
    }
}