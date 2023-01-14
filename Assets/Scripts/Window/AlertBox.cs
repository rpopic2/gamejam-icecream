using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rpopic.Window
{
    public class AlertBox : Window
    {
        public static AlertBox Instance;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Button _okButton;
        [SerializeField] private Image _titleImage;
        [SerializeField] private TMP_Text _titleText;
        private static Action<bool> _onAnswer = delegate { };
        private TaskCompletionSource<bool> _tcs;
        public Task<bool> UserAnswerAsync { get; private set; }
        protected override void Awake()
        {
            if (Instance is null) Instance = this;
            else Destroy(gameObject);
            _cancelButton?.onClick.AddListener(() =>
            {
                Close();
                _tcs.SetResult(false);
                _onAnswer?.Invoke(false);
            });
            _okButton?.onClick.AddListener(() =>
            {
                Close();
                _tcs.SetResult(true);
                _onAnswer?.Invoke(false);
                _onAnswer?.Invoke(true);
            });
            base.Awake();
        }
        public async Task AlertAsync(string text)
        {
            _tcs = new();
            UserAnswerAsync = _tcs.Task;
            InternalOpen(text);
            _cancelButton.gameObject.SetActive(false);
            await UserAnswerAsync;
        }
        public void ImageChoose(Sprite titleSprite, Action<bool> onAnswer)
        {
            Open();
            _titleImage.gameObject.SetActive(true);
            _titleText.gameObject.SetActive(false);
            _cancelButton.gameObject.SetActive(true);
            _titleImage.sprite = titleSprite;
            _onAnswer = onAnswer;
        }
        public void Choose(string text, Action<bool> onAnswer)
        {
            InternalOpen(text);
            _cancelButton.gameObject.SetActive(true);
            _onAnswer = onAnswer;
        }
        private void InternalOpen(string text)
        {
            Open();
            _titleImage?.gameObject.SetActive(false);
            _titleText.gameObject.SetActive(true);
            _cancelButton.gameObject.SetActive(false);
            _titleText.text = text;
        }
    }
}
