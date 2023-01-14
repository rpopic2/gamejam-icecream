using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] private float _time = 5f;
    private Image _image;
#nullable enable
    private Task? _timerTask;
    private Coroutine? _coroutine = null;
    public Action? OnTimerEnd;
    private void Awake()
    {
        Instance = this;
        _image = GetComponentInChildren<Image>();
        ResetTimer();
    }
    public void SetTimer(float time)
    {
        _time = time;
    }
    public async Task StartTimer()
    {
        ResetTimer();
        _coroutine = StartCoroutine(FillAmount());
        var _timeInMilisecond = (int)(_time * 1000);
        await Task.Delay(_timeInMilisecond);
    }
    public void ResetTimer()
    {
        _image.fillAmount = 0;
        if (_coroutine is not null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
    private void Foo()
    {

    }
    private IEnumerator FillAmount()
    {
        var _speed = 1 / _time;
        _image.fillAmount = 0;
        yield return new WaitForEndOfFrame();
        while (_image.fillAmount != 1)
        {
            var fill = Mathf.MoveTowards(_image.fillAmount, 1, _speed * Time.deltaTime);
            _image.fillAmount = fill;
            yield return new WaitForFixedUpdate();
        }
        OnTimerEnd?.Invoke();
        Thread.Yield();
    }
}
