using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Rpopic.Window
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Window : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private float _fadeTime = 0.2f;
        private Coroutine _currentTween;
        private CanvasGroup _canvasGroup;
#nullable enable
        public Action? onOpen;
        protected virtual void Awake()
        {
            if (WindowSystem.instance is null) throw new Exception("A WindowSystem objcet is required to work.");
            _canvasGroup = GetComponent<CanvasGroup>();
            _openButton?.onClick.AddListener(Open);
            _closeButton?.onClick.AddListener(Close);
            _toggle?.onValueChanged.AddListener(Toggle);
        }
        public void OnDisable()
        {
            _canvasGroup.alpha = 0;
        }
        private void SetActiveFalse() => gameObject.SetActive(false);
        public void Open(float time)
        {
            gameObject.SetActive(true);
            if (_toggle is Toggle toggle) toggle.SetIsOnWithoutNotify(true);
            if (_currentTween is not null) StopCoroutine(_currentTween);
            _currentTween = StartCoroutine(Fade(1, time));
            onOpen?.Invoke();
        }
        public void Close(float time)
        {
            _toggle?.SetIsOnWithoutNotify(false);
            StartCoroutine(Fade(0, time, SetActiveFalse));
        }
        private IEnumerator Fade(int target, float time, Action? onComplete = null) {
            var speed = 1 / time;
            while (_canvasGroup.alpha != 1) {
                var fill = Mathf.MoveTowards(_canvasGroup.alpha, 1, speed * Time.deltaTime);
                _canvasGroup.alpha = fill;
                yield return new WaitForFixedUpdate();
                onComplete?.Invoke();
            }
        }
        public void Toggle(bool open)
        {
            if (open) Open();
            else Close();
        }
        ///<summary>
        ///This method is for complying UnityAction
        ///</summary>
        public void Open() => Open(_fadeTime);
        ///<summary>
        ///This method is for complying UnityAction
        ///</summary>
        public void Close() => Close(_fadeTime);
    }
}
