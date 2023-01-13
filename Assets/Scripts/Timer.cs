using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] private float _time = 5f;
    private Image _image;
    private float _speed;
#nullable enable
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
        _speed = 1 / time;
    }
    public void StartTimer()
    {
        ResetTimer();
        _coroutine = StartCoroutine(FillAmount());
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
    private IEnumerator FillAmount()
    {
        _image.fillAmount = 0;
        yield return new WaitForEndOfFrame();
        while (_image.fillAmount != 1)
        {
            var fill = Mathf.MoveTowards(_image.fillAmount, 1, _speed * Time.deltaTime);
            _image.fillAmount = fill;
            yield return new WaitForFixedUpdate();
        }
        OnTimerEnd?.Invoke();
    }
}
