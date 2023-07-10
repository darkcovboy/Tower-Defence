using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float _time;
    private float _remainingTime;

    private MonoBehaviour _context;
    private IEnumerator _countdown;

    public float SpentTime => _time - _remainingTime;

    public Timer(MonoBehaviour context) => _context = context;

    public void Set(float time)
    {
        _time = time;
        _remainingTime = time;
    }

    public void StartTimer()
    {
        _countdown = CountDown();
        _context.StartCoroutine(_countdown);
    }

    public void StopTimer()
    {
        if(_countdown != null)
            _context.StopCoroutine(_countdown);
    }

    private IEnumerator CountDown()
    {
        while(_remainingTime >= 0)
        {
            _remainingTime -= Time.deltaTime;

            yield return null;
        }
    }
}
