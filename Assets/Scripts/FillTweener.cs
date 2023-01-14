using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillTweener : MonoBehaviour
{
    [SerializeField] protected Image _tweenTarget;
    [SerializeField] protected float _time = 5f;
#nullable enable
    protected Coroutine? _coroutine = null;
    public Action? OnTimerEnd;

    protected virtual void Awake()
    {
        ResetTween();
    }
    public void StartTween(int target)
    {
        _coroutine = StartCoroutine(FillAmount(target));
    }
    public void ResetTween()
    {
        _tweenTarget.fillAmount = 0;
        if (_coroutine is not null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
    protected IEnumerator FillAmount(int target)
    {
        var _speed = 1 / _time;
        _tweenTarget.fillAmount = 0;
        while (_tweenTarget.fillAmount != 1)
        {
            var fill = Mathf.MoveTowards(_tweenTarget.fillAmount, target, _speed * Time.deltaTime);
            _tweenTarget.fillAmount = fill;
            yield return new WaitForFixedUpdate();
        }
        OnTimerEnd?.Invoke();
    }

}
