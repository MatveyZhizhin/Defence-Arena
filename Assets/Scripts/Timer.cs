using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _updateTime;
    private float _time;

    public event Action Started;
    public event Action<float> Updated;
    public event Action Ended;

    [SerializeField] private UnityEvent _onTimerEnd;
    [SerializeField] private UnityEvent _onTimerStart;

    private IEnumerator ChangeTime(float time)
    {
        _time = time;

        while (_time > 0)
        {
            yield return new WaitForSecondsRealtime(_updateTime);
            _time -= _updateTime;
            Updated?.Invoke(_time / time);
        }

        EndTimer();
        _time = time;
    }

    public void StartTimer(float time)
    {
        Started?.Invoke();
        _onTimerStart?.Invoke();
        StartCoroutine(ChangeTime(time));

    }
    public void EndTimer()
    {
        Ended?.Invoke();
        _onTimerEnd?.Invoke();
        StopAllCoroutines();
    }
}