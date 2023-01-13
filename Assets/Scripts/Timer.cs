using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time = 5f;
    private Image _image;
    private float _speed;
#nullable enable
    public Action? OnTimerEnd;
    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
        _image.fillAmount = 0;
    }
    public void SetTimer(float time)
    {
        _time = time;
        _speed = 1 / time;
    }
    public void StartTimer()
    {
        StartCoroutine(FillAmount());
    }
    private IEnumerator FillAmount()
    {
        while (_image.fillAmount != 1)
        {
            var fill = Mathf.MoveTowards(_image.fillAmount, 1, _speed * Time.deltaTime);
            _image.fillAmount = fill;
            yield return new WaitForFixedUpdate();
        }
        OnTimerEnd?.Invoke();
    }
}
