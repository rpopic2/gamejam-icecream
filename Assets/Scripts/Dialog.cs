using System.Collections;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private float _typindIntervalSeconds = 0.01f;
    public static Dialog Instance;
    private TMP_Text _dialogText;
    private string _dialog;
    private void Awake()
    {
        Instance = this;
        _dialogText = GetComponent<TMP_Text>();
    }
    public void Talk(string dialog)
    {
        _dialog = dialog;
        StartCoroutine(PrintDialogEffect());
    }
    private IEnumerator PrintDialogEffect()
    {
        int ptr = 0;
        int strlen = _dialog.Length;
        _dialogText.text = "";
        while (ptr < strlen) {
            _dialogText.text += _dialog[ptr++];
            yield return new WaitForSeconds(_typindIntervalSeconds);
        }
    }
}
