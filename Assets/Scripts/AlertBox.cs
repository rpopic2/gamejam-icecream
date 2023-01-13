using System;
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
        protected override void Awake()
        {
            Instance = this;
            _cancelButton?.onClick.AddListener(() =>
            {
                Close();
                _onAnswer?.Invoke(false);
            });
            _okButton?.onClick.AddListener(() =>
            {
                Close();
                _onAnswer?.Invoke(true);
            });
            base.Awake();
        }
        public void Alert(string text, Action<bool> onAnswer)
        {
            InternalOpen(text);
            _cancelButton.gameObject.SetActive(false);
            _onAnswer = onAnswer;
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
