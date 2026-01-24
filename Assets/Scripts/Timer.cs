using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTime;
    private float _time;

    private bool _isStarted;

    public event Action Started;
    public event Action<float> Updated;
    public event Action Ended;

    private void Update()
    {
        if (_isStarted)
        {
            if (_time >= _startTime)
            {
                EndTimer();
                _time = 0;
            }
            else
            {
                _time += Time.deltaTime;
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
        _isStarted = false;
        Ended?.Invoke();
    }
}
