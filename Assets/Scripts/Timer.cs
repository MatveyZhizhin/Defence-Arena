using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _startTime;
        private float _time;

        private bool _isStarted;

        public event Action Started;
        public event Action<float> Updated;
        public event Action Ended;

        private void Start()
        {
            _time = _startTime;
        }

        private void Update()
        {
            if (_isStarted)
            {
                if (_time <= 0)
                {
                    EndTimer();
                    _time = _startTime;
                }
                else
                {
                    _time -= Time.deltaTime;
                    Updated?.Invoke(_time / _startTime);
                }
            }
        }

        public void StartTimer()
        {
            Started?.Invoke();
            _isStarted = true;
        }
        private void EndTimer()
        {
            Ended?.Invoke();
            _isStarted = false;
        }
    }
}
